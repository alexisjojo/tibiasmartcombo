/*  This file is part of Tibia Smart Combo.

    Tibia Smart Combo is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Tibia Smart Combo is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Tibia Smart Combo.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Tibia;
using Tibia.Objects;
using System.Collections;
using System.IO;
using Tibia.Util;
using Tibia.Constants;

namespace ComboClient
{
    public partial class FormBot : Form
    {
        private Tibia.Objects.Client client;
        public Tibia.Objects.Player player;
        public Creature[] creatures;
        private SocketClient socketclient;
        private Tibia.Objects.BattleList bList;
        private Rune UH;
        private Rune SD;
        private Rune EX;
        private string strVocation;
        //private Item StoneSkin;
        private Tibia.Objects.Creature target;
        private int intLagInMs;
        private DateTime dtime;
        private Item HealItem;
        private Item ManaItem;
        private int intHpPerTarget = -1;
        private int intBufferTargetId = -1;
        private bool manashield = false;
        private Tibia.Objects.Console console;
        private FormLogin formLogin;
        private DateTime datetime;
        private bool firstTime = true;
        private bool serverAction = false;
        private int skill;
        private int type;
        private int intShowFloor = 0;
        private int playerFloor = 0; 
        //private bool boolneck = false;
        private bool lvlspy = false;
        private Map map = null;
        private IniReader reader = new IniReader();
        private UserActivityHook actHook;
        private FormMapCopy fMapCopy;
        public bool exite_minimap = false;
        bool useUh = true;

        public FormBot(FormLogin PformLogin, int type)
        {
            this.type = type;
            InitializeComponent();
            this.formLogin = PformLogin;
            login();
          //  fMapCopy = FormMapCopy.Instance(this);
        }



        public void login()
        {
            try
            {
               client = Tibia.Util.ClientChooser.ShowBox();
            }
            catch (Exception e)
            {
                MessageBox.Show("Tibia version doesnt match the bots tibia version: " + e.Message);
            }
            if (client == null || !client.LoggedIn)
            {
                MessageBox.Show("You must have at least one client open and logged in to start this program.");
                
                formLogin.Visible = true;
            }
            else
            {
                rtLog.Text += "Welcome";
                this.Visible = true;
                console = new Tibia.Objects.Console(client);
                map = new Map(client);
                UH = Items.Rune.UltimateHealing;
                SD = Items.Rune.SuddenDeath;
                EX = Items.Rune.Explosion;              
                player = client.GetPlayer();
                labelPlayer.Text = player.Name;
                labelHp.Text = player.HP + "/" + player.HP_Max + "Hp";
                labelMana.Text = player.Mana + "/" + player.Mana_Max + "Mana";
                timerHealingSpell.Start();
                calculateSkill();
                actHook = new UserActivityHook(false, true); // crate an instance with global hooks
                // hang on event
                actHook.KeyUp +=MyKeyPress;
            }
        }

        public void MyKeyPress(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if (client != null && client.LoggedIn)
            {
                if (cbEnableLvlSpy.Checked)
                {
                    int playerFloor = client.GetPlayer().Z;
                    if (key == Keys.Subtract)
                    {
                        if (((playerFloor - intShowFloor != 0 && playerFloor >= 0) || playerFloor < 0) && intShowFloor >= -2 && intShowFloor <= 3)
                        {
                            lvlspy = true;
                            // System.Console.WriteLine(playerFloor);
                            intShowFloor--;
                            map.ShowFloor(intShowFloor, true);
                            client.Statusbar = "" + intShowFloor;
                        }
                        if (playerFloor == 0 && intShowFloor == 0)
                        {
                            intShowFloor = 0;
                            map.ShowFloor(intShowFloor, false);
                        }
                    }
                    else if (key == Keys.Add)
                    {
                        if (((playerFloor < 0 && intShowFloor <= 1) || playerFloor >= 0 || (playerFloor < 0 && intShowFloor < 0)) && intShowFloor >= -3 && intShowFloor <= 2)
                        {
                            lvlspy = true;
                            intShowFloor++;
                            map.ShowFloor(intShowFloor, true);
                            client.Statusbar = "" + intShowFloor;
                        }
                        if (playerFloor == 0 && intShowFloor == 0)
                        {
                            intShowFloor = 0;
                            map.ShowFloor(intShowFloor, false);
                        }
                    }
                    else if (key == Keys.Delete)
                    {
                        intShowFloor = 0;
                        map.ShowFloor(intShowFloor, false);
                    }
                }
                else if (lvlspy)
                {
                    lvlspy = false;
                    intShowFloor = 0;
                    map.ShowFloor(intShowFloor, false);
                }
            }
        }

        public void calculateSkill()
        {
            skill = player.Club;
            if (skill < player.Axe)
                skill = player.Axe;
            if (skill < player.Sword)
                skill = player.Sword;
            if (skill < player.Distance)
                skill = player.Distance;
            if (skill < player.MagicLevel)
                skill = player.MagicLevel;
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            socketclient = SocketClient.Instance(tbServerIp.Text, (int)nuServerPort.Value, this);
            socketclient.connect();
            timerProgram.Start();
            timerManashield.Start();
            if (socketclient.isConnected)
            {
                butStart.Enabled = false;
                butStop.Enabled = true;
            }
            else
            {
                butStart.Enabled = true;
                butStop.Enabled = false;
            }
        }

        private void doPing()
        {
            intLagInMs = socketclient.Ping("209.85.0.2");

            //System.Console.WriteLine(intLagInMs);
            dtime = System.DateTime.Now;
            string strMessage = "<PING>" + player.Name + "</PING>";
            socketclient.send(strMessage);
        }

        private void timerProgram_Tick(object sender, EventArgs e)
        {
           // System.Console.WriteLine("Timer Program");
            if (client == null || client.LoggedIn)
            {
                bList = client.BattleList;
                string strSendList = Protocol.BattleListToString(bList.GetCreatures(), player, manashield, skill);
                manashield = false;
                //if (strSendList.Contains("TARGET"))
                socketclient.send(strSendList);
            }
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            timerProgram.Stop();
            timerManashield.Stop();
            timerPing.Stop();
            if (socketclient != null)
                socketclient.Disconnect();
            if (socketclient.isConnected)
            {
                butStart.Enabled = false;
                butStop.Enabled = true;
            }
            else
            {
                butStart.Enabled = true;
                butStop.Enabled = false;
            }
        }

        public void handleDataReceived(string PStrData)
        {
           // System.Console.WriteLine("Server Data handler");
            if (client == null || !client.LoggedIn)
            {
                return;
            }
            string strActie;
            string strPlayer;
            string[] strAActiePlayer = PStrData.Split(';');
            strActie = strAActiePlayer[0];
            string[] strAActie = strActie.Split('=');
            strActie = strAActie[1];

            switch (strActie)
            {
                case "03": //radarmap
                    XMLParser parser = new XMLParser();
                    XMLElement mainelement = parser.ParseXML( strAActiePlayer[1]);
                    XMLElement currentelement;
                    ArrayList targetList = new ArrayList();
                    int i = 0;
                    
                    while ((currentelement = mainelement.getChild("player", true, i)) != null)
                    {
                        ArrayList list = new ArrayList();
                        for (int i2 = 0; i2 < currentelement.Elements.Length; i2++)
                        {
                            XMLElement newElement = currentelement.Elements[i2];
                            list.Add(newElement.Value);
                        }
                        targetList.Add(list);
                        i++;
                    }
                    if (fMapCopy != null)
                    {
                        fMapCopy.n = 0;
                        fMapCopy.list = targetList;
                    }
                    break;
                case "04":
                    string strVoc = strAActiePlayer[1];
                    string[] strAPlayer = strVoc.Split('=');
                    strVocation = strAPlayer[1];
                    break;
                case "PING":
                    TimeSpan time = dtime - System.DateTime.Now;
                    intLagInMs += Convert.ToInt16(Math.Abs(time.TotalMilliseconds));
                    break;
                default:
                    strPlayer = strAActiePlayer[1];
                    strAPlayer = strPlayer.Split('=');
                    strPlayer = strAPlayer[1];
                    if (client == null || client.LoggedIn)
                    {
                        bList = client.BattleList;
                        List<Creature> creatures = bList.GetCreaturesIgnoreSpace(strPlayer);
                        if (creatures.Count > 0)
                            target = creatures[0];
                        else
                            target = null;
                        if (target != null && timerHealingSpell.Interval <= 100)
                        {
                            switch (strActie)
                            {
                                case "01": //attack
                                    target.Attack();
                                    if (300 - intLagInMs > 0)
                                        System.Threading.Thread.Sleep(300 - intLagInMs);
                                    if (strVocation.Equals("EliteKnight"))
                                    {
                                        //attack de target
                                        int verschil = checkVerschil((Creature)player, target);
                                        if (verschil > 1)
                                        {
                                            if (type == 0)
                                                console.Say("exori hur"); //echt
                                            else
                                                client.Inventory.UseItem(EX, target);       //ot

                                            serverAction = true;
                                        }
                                        else if (verschil > 0)
                                        {
                                            console.Say("exori gran");  //echt
                                            serverAction = true;
                                        }
                                    }
                                    else
                                    {
                                        client.Inventory.UseItem(SD, target);
                                        serverAction = true;
                                    }
                                    break;
                                case "02": //heal
                                    if (cbHealFriend.Checked)
                                    {
                                        if (strVocation.Contains("Knight") ||strVocation.Contains("Paladin"))
                                        {
                                            int verschil = checkVerschil((Creature)player, target);
                                            if (verschil > 1)
                                            {
                                                if(useUh)
                                                    client.Inventory.UseItem(UH, target);
                                                serverAction = true;
                                            }
                                            else if (verschil > 0)
                                            {
                                                    if (player.Level >= 80 && strVocation.Contains("Knight"))
                                                        HealItem = Items.Potion.GreatHealth;
                                                    else
                                                        HealItem = Items.Potion.StrongHealth;
                                                    client.Inventory.UseItem(HealItem, target);
                                                serverAction = true;
                                            }
                                        }
                                        else
                                        {
                                            client.Inventory.UseItem(UH, target);
                                        }
                                        serverAction = true;

                                    }
                                    break;
                                
                                case "05":
                                    break;
                            }
                        }
                        else if (target != null)
                        {
                            target.Attack();
                        }
                    }
                    break;

                    
            }
        }

        public int checkVerschil(Creature Self, Creature Target)
        {
            int verschil = 0;
            int sx = Self.X;
            int sy = Self.Y;
            int sz = Self.Z;
            int tx = Target.X;
            int ty = Target.Y;
            int tz = Target.Z;

            if (sz != tz)
                return -1;

            int verschilx = Math.Abs(sx - tx);
            int verschily = Math.Abs(sy - ty);

            if (verschilx < verschily)
                verschil = verschily;
            else
                verschil = verschilx;
            return verschil;
        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
           // System.Console.WriteLine("Timer ping");
            if (client == null || client.LoggedIn)
            {
                doPing();
            }
        }

        private void timerManashield_Tick(object sender, EventArgs e)
        {
            //System.Console.WriteLine("Timer manashield");
            if (client == null || client.LoggedIn)
            {
                BattleList myBlist = client.BattleList;
                Creature attacking = null;
                int id = player.Target_ID;
                attacking = myBlist.GetCreature(id);
                if (attacking != null && intBufferTargetId != id)
                {
                    intHpPerTarget = attacking.HPBar;
                    intBufferTargetId = attacking.Id;
                }
                else if (attacking != null && intHpPerTarget != attacking.HPBar)
                {
                    manashield = true;
                }
            }
        }

        private void FormBot_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.formLogin.Visible = true;
            if(fMapCopy != null)
            fMapCopy.Close();
        }

        private void timerHealingSpell_Tick(object sender, EventArgs e)
        {
            // System.Console.WriteLine("Timer healingspell");
            if (client == null || client.LoggedIn)
            {
                player = client.GetPlayer();
                if (player != null)
                {
                    int playerFloor2 = player.Z;
                    if (playerFloor2 != playerFloor)
                    {
                        playerFloor = playerFloor2;
                        intShowFloor = 0;
                        map.ShowFloor(intShowFloor, false);
                    }
                    if (cbEnableXray.Checked)
                    {
                        map.ShowNames(true);
                    }
                    else
                    {
                        map.ShowNames(false);
                    }

                    labelPlayer.Text = player.Name;
                    labelHp.Text = player.HP + "/" + player.HP_Max + "Hp";
                    labelMana.Text = player.Mana + "/" + player.Mana_Max + "Mana";
                    timerHealingSpell.Interval = 100;
                    bList = client.BattleList;

                    List<Creature> creatures = bList.GetCreatures(player.Name);
                    Creature self = null;
                    if (creatures.Count > 0)
                        self = creatures[0];
                    if (self != null)
                    {
                        if (player != null && fMapCopy != null)
                        {
                            fMapCopy.player = player;
                        }
                        bool castedmanashield = false;
                        if (cbManashield.Checked && player.Mana >= nuManaManashield.Value && (player.HP <= nuBelowHpMShield.Value || cbHpAlways.Checked))
                        {
                            if (firstTime)
                            {
                                datetime = System.DateTime.Now;
                                console.Say("Utamo Vita");
                                timerHealingSpell.Interval = 1000;
                                castedmanashield = true;
                                firstTime = false;
                                rtLog.Text += "\nExecuting Manashield";
                            }
                            else
                            {
                                TimeSpan compare = System.DateTime.Now - datetime;
                                int seconds = 0;
                                if (type == 0)
                                    seconds = 198;
                                else
                                    seconds = 55;
                                if (compare.TotalSeconds > seconds)
                                {
                                    console.Say("Utamo Vita");
                                    castedmanashield = true;
                                    datetime = System.DateTime.Now;
                                    timerHealingSpell.Interval = 1000;
                                    rtLog.Text += "\nExecuting Manashield";
                                }
                            }
                        }
                        bool healpary = false;
                        if (!castedmanashield && self != null && player.HP < nuHealAtHp.Value && (cbEnableSpellHeal.Checked || cbEnablPotionsRuneHeal.Checked))
                        {
                            heal(self);
                            rtLog.Text += "\nExecuting heal self";
                        }
                        else if (cbManaRestore.Checked && player.Mana < nuRestoreMana.Value)
                        {
                            restoreMana(self);
                            rtLog.Text += "\nExecuting Mana restore";
                        }
                        else if (cbHealPary.Checked)
                        {
                            List<Creature> list = bList.GetPartyMembers((uint)nuHpPerHealParty.Value + 1);
                            Creature healTarget = null;
                            for (int i = 0; i < list.Count; i++)
                            {
                                Creature creaturee = list[i];
                                if (healTarget == null)
                                    healTarget = creaturee;
                                else if (healTarget.IsVisible && healTarget.HPBar > creaturee.HPBar)
                                {
                                    healTarget = creaturee;
                                }
                            }
                            if (healTarget != null && healTarget.IsVisible)
                            {
                                healpary = true;
                                client.Inventory.UseItem(UH, healTarget); 
                                timerHealingSpell.Interval = 1000;
                                rtLog.Text += "\nExecuting heal party";
                            }
                        }
                        else if (!healpary && serverAction)
                        {
                            serverAction = false;
                            timerHealingSpell.Interval = 1000;
                            rtLog.Text += "\nExecuting server action";
                        }
                        /*if (cbStroneSkin.Checked)
                        {
                            ItemLocation neck = new ItemLocation(Tibia.Constants.SlotNumber.Necklace);
                            ItemLocation backpack = new ItemLocation(0, 0);
                            inv = new Inventory(client);
                            List<Tibia.Objects.Container> containers = inv.GetContainers();
                            StoneSkin = inv.FindItem(3081);
                            if (StoneSkin.Loc != null)
                            {
                                if (cbAlwaysStoneSkin.Checked || player.HP <= nuHPstoneSkin.Value)
                                {
                                    if (!boolneck)
                                    {
                                        StoneSkin.Move(neck);
                                        boolneck = true;
                                    }
                                }
                                else
                                {
                                    if (boolneck)
                                    {
                                        boolneck = false;
                                        StoneSkin.Loc = neck;
                                        if (backpack != null)
                                            StoneSkin.Move(backpack);
                                    }
                                }
                            }
                        }*/
                    }
                }
            }
        }
        

        public void heal(Creature self)
        {
         //   System.Console.WriteLine("Heal");
            bool potion = false;
            switch (cbListPotionsHeal.SelectedIndex)
            {
                case 0:
                    HealItem = Items.Potion.UltimateHealth;
                    potion = true;
                    break;
                case 1:
                    HealItem = Items.Potion.GreatHealth;
                    potion = true;
                    break;
                case 2:
                    HealItem = Items.Potion.StrongHealth;
                    potion = true;
                    break;
                case 3:
                    HealItem = Items.Potion.Health;
                    potion = true;
                    break;
                case 4:
                    HealItem = Items.Rune.UltimateHealing;
                    break;
                case 5:
                    HealItem = Items.Rune.IntenseHealing;
                    break;
                default:
                    HealItem = Items.Potion.UltimateHealth;
                    break;
            }
            if (cbEnableSpellHeal.Checked)
            {
                SpellList list = new SpellList();
                Spell spell = list.FindSpell(tbSpell.Text);
                if (spell != null && spell.ManaPoints < player.Mana)
                {
                    if (cbEnablPotionsRuneHeal.Checked && cbCombineSpellPotion.Checked && self != null)
                    {
                        client.Inventory.UseItem(HealItem, self);
                        timerHealingSpell.Interval = 1000;
                    }
                    console.Say(tbSpell.Text);
                    if (potion && self != null)
                        client.Inventory.UseItem(HealItem, self);
                    timerHealingSpell.Interval = 1000;

                }
                else if (cbEnablPotionsRuneHeal.Checked && self != null)
                {
                    client.Inventory.UseItem(HealItem, self); 
                    timerHealingSpell.Interval = 1000;
                }
                else if (cbManaRestore.Checked && player.Mana < nuRestoreMana.Value && self != null)
                {
                    restoreMana(self);
                }
            }
            else if (cbEnablPotionsRuneHeal.Checked && self != null)
            {
                client.Inventory.UseItem(HealItem, self);
                timerHealingSpell.Interval = 1000;
            }
        }

        public void restoreMana(Creature self)
        {
      //      System.Console.WriteLine("Restore mana");
            switch (cbListManaPotions.SelectedIndex)
            {
                case 0:
                    ManaItem = Items.Potion.GreatMana;
                    break;
                case 1:
                    ManaItem = Items.Potion.StrongMana;
                    break;
                case 2:
                    ManaItem = Items.Potion.Mana;
                break;
            }
            client.Inventory.UseItem(ManaItem, self);
            timerHealingSpell.Interval = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open the ini file";
            openFileDialog1.InitialDirectory = @"\\";
            openFileDialog1.Filter = "Ini File (*.ini*)|*.ini*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Hashtable inifile = reader.ReadFile(openFileDialog1.FileName);
                if (inifile.Count == 23)
                {
                    //server
                    tbServerIp.Text = (string)inifile["server_ip"];
                    nuServerPort.Value = Convert.ToInt32((string)inifile["server_port"]);
                    //healing
                    nuHealAtHp.Value = Convert.ToInt32((string)inifile["heal_below"]);
                    cbListPotionsHeal.SelectedIndex = Convert.ToInt32((string)inifile["heal_runepotion"]);
                    tbSpell.Text = (string)inifile["heal_spell"];
                    cbHealPary.Checked = stringToBool((string)inifile["heal_party"]);
                    nuHpPerHealParty.Value = Convert.ToInt32((string)inifile["heal_partypre"]);
                    cbHealFriend.Checked = stringToBool((string)inifile["heal_server"]);
                    cbEnableSpellHeal.Checked = stringToBool((string)inifile["heal_spellenable"]);
                    cbEnablPotionsRuneHeal.Checked = stringToBool((string)inifile["heal_runepotionenable"]);
                    //magic
                    cbListManaPotions.SelectedIndex = Convert.ToInt32((string)inifile["restore_type"]);
                    nuRestoreMana.Value = Convert.ToInt32((string)inifile["restore_mana"]);
                    cbManaRestore.Checked = stringToBool((string)inifile["restore_enable"]);
                    nuManaManashield.Value = Convert.ToInt32((string)inifile["shield_mana"]);
                    nuBelowHpMShield.Value = Convert.ToInt32((string)inifile["shield_hp"]);
                    cbHpAlways.Checked = stringToBool((string)inifile["shield_always"]);
                    cbManashield.Checked = stringToBool((string)inifile["shield_enable"]);
                    cbCombineSpellPotion.Checked = stringToBool((string)inifile["CombineSpellPotion"]);
                    //protection
                    //nuHPstoneSkin.Value = Convert.ToInt32((string)inifile["stoneskin_hp"]);
                    //cbStroneSkin.Checked = stringToBool((string)inifile["stoneskin_enable"]);
                    //cbAlwaysStoneSkin.Checked = stringToBool((string)inifile["stoneskin_always"]);
                    //other
                    cbEnableLvlSpy.Checked = stringToBool((string)inifile["lvlspy_enable"]);
                    cbEnableXray.Checked = stringToBool((string)inifile["lvlspy_xray"]);
                }
            }
        }


        private bool stringToBool(string str)
        {
            if (str.Equals("true"))
                return true;
            else
                return false;
        }

        private string boolToString(bool boO)
        {
            if (boO)
                return "true";
            else
                return "false";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "[Server]\r\n";
            //server
            text += "server_ip=" + tbServerIp.Text + "\r\n";
            text += "server_port=" + nuServerPort.Value + "\r\n";
            text += "[/Server]" + "\r\n";
            //healing
            text += "[Healing]" + "\r\n";
            text += "heal_below=" + nuHealAtHp.Value + "\r\n";
            text += "heal_runepotion=" + cbListPotionsHeal.SelectedIndex + "\r\n";
            text += "heal_spell=" + tbSpell.Text + "\r\n";
            text += "heal_party=" + boolToString(cbHealPary.Checked) + "\r\n";
            text += "heal_partypre=" + nuHpPerHealParty.Value + "\r\n";
            text += "heal_server=" + boolToString(cbHealFriend.Checked) + "\r\n";
            text += "heal_spellenable=" + boolToString(cbEnableSpellHeal.Checked) + "\r\n";
            text += "heal_runepotionenable=" + boolToString(cbEnablPotionsRuneHeal.Checked) + "\r\n";
            text += "[/Healing]" + "\r\n";
            //magic
            text += "[Magic]" + "\r\n";
            text += "restore_type=" + cbListManaPotions.SelectedIndex + "\r\n";
            text += "restore_mana=" + nuRestoreMana.Value + "\r\n";
            text += "restore_enable=" + boolToString(cbManaRestore.Checked) + "\r\n";
            text += "CombineSpellPotion=" + boolToString(cbCombineSpellPotion.Checked) + "\r\n";
            text += "shield_mana=" + nuManaManashield.Value + "\r\n";
            text += "shield_hp=" + nuBelowHpMShield.Value + "\r\n";
            text += "shield_always=" + boolToString(cbHpAlways.Checked) + "\r\n";
            text += "shield_enable=" + boolToString(cbManashield.Checked) + "\r\n";
            text += "[/Magic]" + "\r\n";
            /*protection
            text += "[Protection]" + "\r\n";
            text += "stoneskin_hp=" + nuHPstoneSkin.Value + "\r\n";
            text += "stoneskin_enable=" + boolToString(cbStroneSkin.Checked) + "\r\n";
            text += "stoneskin_always=" + boolToString(cbAlwaysStoneSkin.Checked) + "\r\n";
            text += "[/Protection]" + "\r\n";*/
            //other
            text += "[Other]" + "\r\n";
            text += "lvlspy_enable=" + boolToString(cbEnableLvlSpy.Checked) + "\r\n";
            text += "lvlspy_xray=" + boolToString(cbEnableXray.Checked) + "\r\n";
            text += "[/Other]";

            saveFileDialog1.Title = "Save the ini file";
            saveFileDialog1.InitialDirectory = @"\\";
            saveFileDialog1.Filter = "Ini File (*.ini*)|*.ini*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                reader.WriteFile(file, text);
            }
        }

        private void butMinimap_Click(object sender, EventArgs e)
        {
            fMapCopy = new FormMapCopy(this);
            fMapCopy.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            useUh = checkBox1.Checked;
        }
    }
}
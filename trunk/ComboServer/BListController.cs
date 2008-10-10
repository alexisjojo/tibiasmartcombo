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
using System.Text;
using System.Collections;
using System.Timers;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace ComboServer
{
    public class BListController
    {
        Socketserver server;

        bool healMage = true;
        bool doHealMage = true;
        bool healKnight = true;
        bool doHealKnight = false;
        bool healPal = true;
        bool doHealPal = false;

        public bool smartcombo = true;
        public int noobcharlvl = 40;

        bool detectManashield = false;
        double sensitivity = 2.0;
        ArrayList hitList;
        ArrayList healList;
        String strTop300;
        Protectionzones protzones;
        XMLParser parser;
        Timer timerPickTarget = new Timer();
        Timer timerSendRadar = new Timer();
        Timer timerUpdateTargets = new Timer();
        Timer timerUpdateManashield = new Timer();
        int playersattacked = 0;
        int playershealed = 0;
        int knightHeal;
        int mageHeal;
        int palHeal;
        public bool radar = true;

        public int KnightHeal
        {
            set { knightHeal = value; }
        }
        public int MageHeal
        {
            set { mageHeal = value; }
        }
        public int PalHeal
        {
            set { palHeal = value; }
        }

        public bool HealMage
        {
            set { healMage = value; }
        }
        public bool DoHealMage
        {
            set { doHealMage = value; }
        }
        public bool HealKnight
        {
            set { healKnight = value; }
        }
        public bool DoHealKnight
        {
            set { doHealKnight = value; }
        }
        public bool HealPal
        {
            set { healPal = value; }
        }
        public bool DoHealPal
        {
            set { doHealPal = value; }
        }
  

        public int PlayersAttacked
        {
            set {
                playersattacked += value;
                server.formMain.PlayersAttacked = playersattacked;
            }
        }

        public int PlayersHealed
        {
            set
            {
                playershealed += value;
                server.formMain.PlayersHealed = playershealed;
            }
        }

        public bool DetectManashield
        {
            set { detectManashield = value; }
        }

        public double Sensitivity
        {
            set
            {
                sensitivity = value;
            }
        }
        public BListController(Socketserver server, string world)
        {
            protzones = new Protectionzones(false);
            this.server = server;
            parser = new XMLParser();
            hitList = new ArrayList();
            healList = new ArrayList();
            strTop300 = getTop300(world);
            updateEnemys();
            timerPickTarget.Elapsed += new ElapsedEventHandler(run);
            timerPickTarget.Interval = 1000;
            timerPickTarget.Start();
            timerSendRadar.Elapsed += new ElapsedEventHandler(sendRadar);
            timerSendRadar.Interval = 1000;
            timerSendRadar.Start();
            timerUpdateTargets.Elapsed += new ElapsedEventHandler(updateTargets);
            timerUpdateTargets.Interval = 100;
            timerUpdateTargets.Start();
            timerUpdateManashield.Elapsed += new ElapsedEventHandler(updateManashield);
            timerUpdateManashield.Interval = 100;
            timerUpdateManashield.Start();
        }

        public void sendRadar(Object sender, ElapsedEventArgs e)
        {
            if (radar)
            {
                string message = Protocol.MaakCommandoRadar("03", hitList, healList, noobcharlvl);
                if (message.Length > 32)
                    server.sendAll(message);
            }
        }

        public void updateEnemys()
        {
            hitList = new ArrayList();
            System.Console.ForegroundColor = ConsoleColor.Blue;
            server.formMain.Log = "Editing enemy list";
            hitList = getAndWriteLvlVoc(hitList, "hitlist.txt", strTop300);
            hitList = Calculations.calculateHP(hitList);
             System.Console.ForegroundColor = ConsoleColor.Green;
            server.formMain.Log = "Succesfull";
        }

        private string getVocation(string PNaam)
        {
            string strHtmlPlayer = getPlayer(PNaam);
            //CharacterInformationName:VincentAvatarSex:maleProfession:KnightLevel:18World:RuberaResidence:CarlinLastlogin:Dec 18 2007, 17:27:43 CETComment:Startedon24December2005
            string strVocation = getWaardeBetween(strHtmlPlayer, "Profession:", "Level:");
            strVocation = getWaardeBetween(strVocation, "<TD>", "</TD>");
            return strVocation;
        }

        public void submitList(string PstrName, string PstrLvl, string PstrHp, string PstrHpPer, string PstrMagicLvl, string Pstrxyz, string PstrSkill, ArrayList PALBlist, int id)
        {
            if (PstrHpPer.Equals("0"))
                return;

            string vocation;
            string name = PstrName.Replace(" ", "");
            int n2 = ArraySupport.getValueFromArray(healList, name, 1);
            if (n2 >= 0)
            {
                ArrayList list = (ArrayList)(healList[n2]);
                vocation = (string)(list[1]);
            }
            else 
            {
                vocation = getVocation(PstrName);
            }
            
            PstrName = PstrName.Replace(" ", "");
            ArrayList ALSelf = new ArrayList();
            ALSelf.Add(PstrName);
            ALSelf.Add(vocation);
            ALSelf.Add(PstrLvl);
            ALSelf.Add(PstrHp);
            ALSelf.Add(PstrHpPer);
            ALSelf.Add(PstrMagicLvl);
            ALSelf.Add(Pstrxyz);
            ALSelf.Add(PstrSkill);
            ALSelf.Add(id);
            ALSelf.Add(0);

            if (n2 >= 0)
            {
                healList[n2] = ALSelf;
                
            }
            else
            {
                healList.Add(ALSelf);
                server.sendAll(Protocol.MaakCommando("04", vocation));//, id);
            }
            for (int i = 0; i < PALBlist.Count; i++)
            {
                ArrayList list = (ArrayList)PALBlist[i];
                string targetName = (string)list[0];
                targetName = targetName.Replace(" ", "");
                n2 = ArraySupport.getValueFromArray(hitList, targetName, 1);
                if (n2 >= 0)
                {
                    ArrayList value = (ArrayList)hitList[n2];
                    ArrayList array = (ArrayList)value[5];
                    int n = ArraySupport.getValueFromArray(array, PstrName);
                    if (n != -1)
                        array[n] = PstrName + "," + 0;
                    else
                        array.Add(PstrName + "," + 0);
                    value[5] = array;
                    value[4] = list[1];
                    value[6] = list[2];
                    if (list[3].Equals("GEEN"))
                    {
                        value[7] = list[3];
                        value[8] = 0;
                    }
                    value[9] = 0;
                    hitList[n2] = value;
                }
                int n3 = ArraySupport.getValueFromArray(healList, targetName, 1);
                if (n3 >= 0)
                {
                    ArrayList hal = (ArrayList)healList[n3];
                    hal[4] = list[1];
                    hal[6] = list[2];
                    healList[n3] = hal;
                }
            }
        }

        public void updateManashield(Object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < hitList.Count; i++)
            {
                ArrayList list = (ArrayList)hitList[i];
                int intTimer = Convert.ToInt16(list[8]);
                if (intTimer >= 2000)//2sec
                {
                    list[7] = "?";
                    intTimer = 0;
                }
                else
                {
                    intTimer += 100;
                    list[8] = "" + intTimer;
                }
                hitList[i] = list;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void pickTarget()
        {
            if (smartcombo)
            {
                for (int i = 0; i < hitList.Count; i++)
                {
                    ArrayList realPlayersDone = new ArrayList();
                    ArrayList secondArray = (ArrayList)hitList[i];
                    if (!protzones.inPz((string)secondArray[6]))
                    {
                        ArrayList thirdArray = (ArrayList)secondArray[5];
                        ArrayList array = new ArrayList();
                        ArrayList playersDone = new ArrayList();
                        for (int i2 = 0; i2 < thirdArray.Count; i2++)
                        {
                            string str = (string)thirdArray[i2];
                            string[] strA = str.Split(',');
                            str = strA[0];
                            int n = ArraySupport.getValueFromArray(healList, str, 1);


                            int n2 = ArraySupport.getValueFromArray(realPlayersDone, str, 1);
                            if (n2 == -1  && n != -1)
                            {
                                ArrayList atk = (ArrayList)healList[n];
                                if (!protzones.inPz((string)atk[6]))
                                {
                                    array.Add(atk);
                                }
                                playersDone.Add(healList[n]);
                            }
                        }
                        int intComboDmg = Calculations.calulateCombodmg(array, (string)secondArray[6]);
                        intComboDmg = (int)(intComboDmg * sensitivity);
                        string strHp = (string)secondArray[3];
                        string strHpPer = (string)secondArray[4];
                        int intHpEnemy = Convert.ToInt16(strHp);
                        int intPer = Convert.ToInt16(strHpPer);
                        float test = intHpEnemy;
                        float test1 = test / 100;
                        float test2 = (float)intPer;
                        float test3 = test1 * test2;
                        intHpEnemy = Convert.ToInt16(test3);
                        bool manashield = Calculations.checkEnemyShield((string)secondArray[1], (string)secondArray[7]);
                        if(manashield && detectManashield)
                        {
                            int maxMana = Calculations.getMaxMana((string)secondArray[1], Convert.ToInt16(secondArray[2]));
                            intHpEnemy += maxMana;
                        }
                        if (intComboDmg > intHpEnemy && intHpEnemy != -1)
                        {
                            for (int i3 = 0; i3 < playersDone.Count; i3++)
                            {
                                realPlayersDone.Add(playersDone[i3]);
                            }
                            PlayersAttacked = 1;
                            server.sendAll(Protocol.MaakCommando("01", (string)secondArray[0]));
                            server.formMain.Log = "\n\n";
                            server.formMain.Log = "Attacking " + (string)secondArray[0];
                        }
                    }
                }
            }
        }

        public void checkHeal()
        {
            for (int i = 0; i < healList.Count; i++)
            {
                ArrayList aself = (ArrayList)healList[i];
                int hpPer = Convert.ToInt16((string)aself[4]);
                string voc = (string)aself[1];
                string naam = (string)aself[0];
                if (healKnight && hpPer < knightHeal && hpPer > 0 && voc.Equals("Knight"))
                {
                    heal(naam);
                }
                if (healMage && hpPer < mageHeal && hpPer > 0 && voc.Equals("Mage"))
                {
                    heal(naam);
                }
                if (healPal && hpPer < palHeal && hpPer > 0 && voc.Equals("Paladin"))
                {
                    heal(naam);
                }
            }
        }

        public void heal(string naam)
        {
            PlayersHealed = 1;
            server.formMain.Log = "\n";
            server.formMain.Log = "Healing " + naam;
            sendHeal(naam);
        }

        public void removeClient(int id)
        {
            for (int i = 0; i < healList.Count; i++)
            {
                ArrayList aself = (ArrayList)healList[i];
                if ((int)aself[8] == id+1)
                    healList.RemoveAt(i);
            }
        }

        public void sendHeal(string naam)
        {
            for (int i = 0; i < healList.Count; i++)
            {
                ArrayList aself = (ArrayList)healList[i];
                string voc = (string)(aself[1]);
                if (voc.Equals("Mage") && doHealMage)
                {
                    server.send(Protocol.MaakCommando("02", naam), (int)aself[8]);
                }
                else if (voc.Equals("Paladin") && doHealPal)
                {
                    server.send(Protocol.MaakCommando("02", naam), (int)aself[8]);
                }
                else if (voc.Equals("Knight") && doHealKnight)
                {
                    server.send(Protocol.MaakCommando("02", naam), (int)aself[8]);
                }
            }
        }

        public void updateTargets(Object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < hitList.Count; i++)
            {
                ArrayList list = (ArrayList)hitList[i];
                ArrayList array = (ArrayList)list[5];
                for (int n = 0; n < array.Count; n++)
                {
                    string str = (string)array[n];
                    string[] strA = str.Split(',');
                    int gezien = Convert.ToInt16(strA[1]);
                    if (gezien >= 10)
                    {
                        array.RemoveAt(n);
                    }
                    else
                    {
                        str = strA[0] + ","+  (Convert.ToInt16(strA[1]) + 1);
                        array[n] = str;
                    }
                }
                list[5] = array;
                int intList = Convert.ToInt32(list[9]);
                if (intList != -1)
                    list[9] = intList+1;

                hitList[i] = list;
            }
            for (int i = 0; i < healList.Count; i++)
            {
                ArrayList list = (ArrayList)healList[i];
                int intList = Convert.ToInt32(list[9]);
                if (intList != -1)
                    list[9] = intList + 1;
                healList[i] = list;
            }

        }

        public void run(Object sender, ElapsedEventArgs e)
        {
            pickTarget();
            checkHeal();
        }

        public string getTop300(string world)
        {
            string strHttp = "";
            try
            {
                System.Console.ForegroundColor = ConsoleColor.Blue;
                server.formMain.Log = "Getting Top 300";
                string sURL;
                sURL = "http://www.erig.net/xphist.php?world=" + world ;

                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);

                WebProxy myProxy = new WebProxy("myproxy", 80);
                myProxy.BypassProxyOnLocal = true;

                wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                wrGETURL.Timeout = 10000;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = "";
                int i = 0;

                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    strHttp += sLine;
                }
                strHttp = strHttp.Replace(" ", "");
                server.formMain.Log = "Succesfull";
            }
            catch (Exception e)
            {
                server.formMain.Log = "Cant load page " + e.Message;
            }

            return strHttp;
        }

        public string getPlayer(String PstrNaam)
        {
            string sURL;
            sURL = "http://www.tibia.com/community/?subtopic=characters&name=" + PstrNaam;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

            wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;
            string strHttp = "";

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                strHttp += sLine;
            }
            strHttp = strHttp.Replace(" ", "");
            return strHttp;
        }

        public ArrayList getAndWriteLvlVoc(ArrayList PAList, string file, string strHttp)
        {           
            StreamReader tr = new StreamReader(file);
            string strRegel;
            int index;
            while ((strRegel = tr.ReadLine()) != null)
            {
                string strHttpBuf = strHttp;
                string strRegel2 = strRegel.Replace(" ", "");
                string strTitle = "XPHistoryof" + strRegel2;
                if (ArraySupport.getValueFromArray(PAList, strRegel2, 1) == -1)
                {
                    index = strHttpBuf.IndexOf(strTitle);
                    if (index != -1)
                    {
                        strHttpBuf = strHttpBuf.Substring(index, strHttpBuf.Length - index);
                        index = strHttpBuf.IndexOf("<tdclass='r'>");
                        strHttpBuf = strHttpBuf.Substring(index, strHttpBuf.Length - index);
                        string strVocation = "";
                        for (int i2 = 13; i2 < strHttpBuf.Length; i2++)
                        {
                            if (strHttpBuf[i2].Equals('<'))
                                break;
                            strVocation += strHttpBuf[i2];
                        }
                        string strTrim = "<tdclass='r'>" + strVocation + "</td><tdclass='r'>";
                        strHttpBuf = strHttpBuf.TrimStart(strTrim.ToCharArray());
                        string strLvl = "";
                        for (int i2 = 0; i2 < strHttpBuf.Length; i2++)
                        {
                            if (strHttpBuf[i2].Equals('<'))
                                break;
                            strLvl += strHttpBuf[i2];
                        }
                        ArrayList arrayList = new ArrayList();
                        ArrayList arrayList2 = new ArrayList();
                        arrayList.Add(strRegel2);
                        arrayList.Add(strVocation);
                        arrayList.Add(strLvl);
                        arrayList.Add("-1");
                        arrayList.Add("100");
                        arrayList.Add(arrayList2);
                        arrayList.Add("32326,31776,8");
                        arrayList.Add("?");
                        arrayList.Add("0");
                        arrayList.Add("-1");
                        PAList.Add(arrayList);
                    }
                    else
                    {
                        string strHtmlPlayer = getPlayer(strRegel);
                        //CharacterInformationName:VincentAvatarSex:maleProfession:KnightLevel:18World:RuberaResidence:CarlinLastlogin:Dec 18 2007, 17:27:43 CETComment:Startedon24December2005
                        string strVocation = getWaardeBetween(strHtmlPlayer, "Profession:", "Level:");
                        strVocation = getWaardeBetween(strVocation, "<TD>", "</TD>");
                        string strLvl = getWaardeBetween(strHtmlPlayer, "Level:", "World:");
                        strLvl = getWaardeBetween(strLvl, "<TD>", "</TD>");
                        if (strVocation != null)
                        {
                            ArrayList arrayList = new ArrayList();
                            ArrayList arrayList2 = new ArrayList();
                            arrayList.Add(strRegel2);
                            arrayList.Add(strVocation);
                            arrayList.Add(strLvl);
                            arrayList.Add("-1"); //hp
                            arrayList.Add("100"); //hpperc
                            arrayList.Add(arrayList2); //attackers
                            arrayList.Add("32326,31776,8"); //x y z
                            arrayList.Add("?"); // manashield   ? = onbeken  GEEN = geen manashield
                            arrayList.Add("0"); //manashield timer
                            arrayList.Add("-1"); //radar timer
                            PAList.Add(arrayList);
                        }
                        else
                            server.formMain.Log = strRegel + " Does not exists.";
                    }
                }
            }
            tr.Close();
            return PAList;
        }

        public string getWaardeBetween(string PstrString, string PstrVan, string PstrTot)
        {
            if (PstrString != null)
            {
                int intIndexVan = PstrVan.Length + PstrString.IndexOf(PstrVan);
                int intIndexTot = PstrString.IndexOf(PstrTot, intIndexVan);
                if (intIndexTot != -1)
                    return PstrString.Substring(intIndexVan, intIndexTot - intIndexVan);                   
            }
           return null;
        }
    }
}

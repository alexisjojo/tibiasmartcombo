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
using System.IO;

namespace ComboServer
{
    public partial class Form_Main : Form
    {
        Socketserver server;
        private String world;
        private bool started = false;
        private int playersInhitlist = 0;
        string text;
        int playersattacked = 0;
        int playershealed = 0;

        public int PlayersAttacked
        {
            set
            {
                playersattacked = value;
            }
        }
        public int PlayersHealed
        {
            set
            {
                playershealed = value;
            }
        }

        public Form_Main()
        {
            InitializeComponent();
            CBworld.SelectedIndex = 3;
            refreshList();
            timerRefresh.Start();
        }

        public void refreshList()
        {
            playersInhitlist = 0;
            StreamReader tr = new StreamReader("hitlist.txt");
            String line = tr.ReadLine();
            if (line != null)
            {
                rtHitlist.Text = line + "\n";
                playersInhitlist++;
            }
            else
            {
                rtHitlist.Text = "Empty hitist add some targets\n";
            }
            line = tr.ReadLine();
            while (line != null)
            {
                playersInhitlist++;
                rtHitlist.Text += line + "\n";
                line = tr.ReadLine();
            }
            tr.Close();
            labelHitlist.Text = playersInhitlist.ToString();
        }

        public string World
        {
            get
            {
                return world;
            }
        }

        public string Log
        {
            set
            {
                text += value + "\n";
            }
        }

        private void ButStartList_Click(object sender, MouseEventArgs e)
        {
            if (!started)
            {
                Log = "\n\n\n\n\n";
                if (CBworld.SelectedItem != null)
                {
                    world = (string)CBworld.SelectedItem;
                }
                ButStartList.Text = "Stop Listening";
                server = new Socketserver((int)nuPort.Value, this);
                server.connect();
                started = true;
            }
            else
            {
                Log = "\n";
                ButStartList.Text = "Start Listening";
                server.CloseSockets();
                started = false;
            }
        }

        private void butAddHit_Click(object sender, EventArgs e)
        {
            StreamReader tr = new StreamReader("hitlist.txt");    
            string line = tr.ReadLine();
            string text = tbNameTarget.Text;
            bool inlist = false;
           // string lineNoSpace = line.Trim(' ');
            while (line != null)
            {
                if(line.Trim(' ').Equals(text.Trim(' ')))
                    inlist = true;
                line = tr.ReadLine();
            }
            tr.Close();
            if (!inlist)
            {
                StreamWriter sw = new StreamWriter("hitlist.txt",true);
                sw.WriteLine(text);
                sw.Close();
                refreshList();
            }
        }

        private void butRemoveHit_Click(object sender, EventArgs e)
        {
            StreamReader tr = new StreamReader("hitlist.txt");
            StreamWriter sw = new StreamWriter("hitlistWriter.txt", false);
            string line = tr.ReadLine();
            string text = tbNameTarget.Text;
            while (line != null)
            {
                if (!line.Trim(' ').Equals(text.Trim(' ')))
                {
                    sw.WriteLine(line);
                }
                line = tr.ReadLine();
            }
            sw.Close();
            tr.Close();
            tr = new StreamReader("hitlistWriter.txt");
            sw = new StreamWriter("hitlist.txt", false);

            line = tr.ReadLine();
            while (line != null)
            {
                sw.WriteLine(line);
                line = tr.ReadLine();
            }
            sw.Close();
            tr.Close();
            refreshList();
        }

        private void ButReHitlist_Click(object sender, EventArgs e)
        {
            if (server != null)
                server.blist.updateEnemys();
            else
                Log = "Start the server first";
        }

        private void nuComboSen_ValueChanged(object sender, EventArgs e)
        {
            server.blist.Sensitivity = (double)nuComboSen.Value;
        }

        private void cbDetectMs_EnabledChanged(object sender, EventArgs e)
        {
            server.blist.DetectManashield = cbDetectMs.Checked;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            labelAttacked.Text = playersattacked.ToString();
            labelHealed.Text = playershealed.ToString();
            if (text != "")
            {
                rtLog.Text = text + rtLog.Text;
                 text = "";
            }
               
        }

        private void cbEnableKnightGetHeal_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.HealKnight = cbEnableKnightGetHeal.Checked;
        }

        private void cbEnableKnightCastHeal_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.DoHealKnight = cbEnableKnightCastHeal.Checked;
        }

        private void cbEnableMageGetHeal_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.HealMage = cbEnableMageGetHeal.Checked;
        }

        private void cbEnableMageCastHeal_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.DoHealMage = cbEnableMageCastHeal.Checked;
        }

        private void cbEnablePalGetHeal_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.HealPal = cbEnablePalGetHeal.Checked;
        }

        private void cbEnablePalCastHeal_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.DoHealPal = cbEnablePalCastHeal.Checked;
        }

        private void nuMageHeal_ValueChanged(object sender, EventArgs e)
        {
            server.blist.MageHeal = Convert.ToInt16(nuMageHeal.Value);
        }

        private void nuPaladinHeal_ValueChanged(object sender, EventArgs e)
        {
            server.blist.PalHeal = Convert.ToInt16(nuPaladinHeal.Value);
        }

        private void nuKnightHeal_ValueChanged(object sender, EventArgs e)
        {
            server.blist.KnightHeal = Convert.ToInt16(nuKnightHeal.Value);
        }

        private void cbRadar_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.radar = cbRadar.Checked;
        }

        private void cbSmartCombo_CheckedChanged(object sender, EventArgs e)
        {
            server.blist.smartcombo = cbSmartCombo.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            server.blist.noobcharlvl = (int)numericUpDown1.Value;
        }
    }
}
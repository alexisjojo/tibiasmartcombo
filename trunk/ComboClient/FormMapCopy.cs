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
using Tibia;
using Tibia.Objects;
using System.IO;
using System.Collections;
using Tibia.Util;


namespace ComboClient
{
    public partial class FormMapCopy : Form
    {
        private static FormMapCopy instanceFormMapCopy = null;
        public MyMap mapviewer;
        FormBot fb;
        public Player player;
        private Location playerLocation;
        public ArrayList list;
        public int n = 0;

        public void CleanImageFolder()
        {
            string imgFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tibia\\Automap\\";
            string[] imgList = Directory.GetFiles(imgFolder, "*.png");
            foreach (string img in imgList)
            {
                FileInfo imgInfo = new FileInfo(img);
                imgInfo.Delete();
            }
        }

        public static FormMapCopy Instance(FormBot fb)
        {
            if (instanceFormMapCopy == null)
                instanceFormMapCopy = new FormMapCopy(fb);
            return instanceFormMapCopy;
        }
        public FormMapCopy(FormBot fb)
        {
            this.fb = fb;
            InitializeComponent();
            this.Visible = true;
            mapviewer = new MyMap(this.pictureBox1, this);
            mapviewer.LoadMap();
            player = fb.player;
            System.Console.WriteLine("Playessrs x,y,z" + player.Location.X + ", " + player.Location.Y + ", " + player.Location.Z);

            playerLocation = player.Location;
            mapviewer.SetMapCenter(playerLocation);

            mapviewer.SetLevel(0);
            mapviewer.SetLevel(1);
            mapviewer.SetLevel(2);
            mapviewer.SetLevel(3);
            mapviewer.SetLevel(4);
            mapviewer.SetLevel(5);
            mapviewer.SetLevel(6);
            mapviewer.SetLevel(7);
            mapviewer.SetLevel(8);
            mapviewer.SetLevel(9);
            mapviewer.SetLevel(10);
            mapviewer.SetLevel(11);
            mapviewer.SetLevel(12);
            mapviewer.SetLevel(13);

            mapviewer.SetLevel(playerLocation.Z);
        }

        public void setMarkers()
        {
            if (player != null)
            {
                if (player.Location.X != playerLocation.X || player.Location.Y != playerLocation.Y || player.Location.Z != playerLocation.Z)
                {
                    playerLocation = player.Location;
                    mapviewer.SetLevel(playerLocation.Z);
                    mapviewer.SetMapCenter(playerLocation);
                }
                //mapviewer.DrawCreatureMarker((Creature)player, true);
            }
            if (list != null)
            {
                n++;
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList alPlayer = (ArrayList)list[i];
                    string naam = (string)alPlayer[0];
                    int status = Convert.ToInt16(alPlayer[1]);
                    int lox = Convert.ToInt32(alPlayer[2]);
                    int loy = Convert.ToInt32(alPlayer[3]);
                    int loz = Convert.ToInt32(alPlayer[4]);
                    int timems = Convert.ToInt32(alPlayer[5]);
                    timems /= 10;
                    //System.Console.WriteLine("status: " + status);

                    Color textFill = Color.White;
                    Color markerFill = Color.Yellow;

                    if (status > 3)
                    {
                        textFill = Color.Red;
                        if (status == 4 || status == 5)
                            markerFill = Color.Yellow;
                        else if (status == 7)
                            markerFill = Color.Purple;
                        else if (status == 6)
                            markerFill = Color.White;
                    }
                    else if (status >= 0)
                    {
                        textFill = Color.Green;
                        //     if (status == 0)
                        //  markerFill = Color.Blue;
                        if (status == 1)
                            markerFill = Color.Yellow;
                        else if (status == 2)
                            markerFill = Color.Purple;
                        else if (status == 3)
                            markerFill = Color.White;
                    }

                    if (textFill != null && markerFill != null && status != 0)
                        mapviewer.DrawMarker(new Location(lox, loy, loz), naam + "/" + timems, markerFill, Color.Black, textFill, Color.Black);
                }
                //list = null;
            }
            if (n > 1000)
                list = null;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            mapviewer.RedrawMap();
        }

        private void FormMapCopy_FormClosed(object sender, FormClosedEventArgs e)
        {
            mapviewer.close();
            this.Visible = false;
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            mapviewer.close();
            this.Close();
            CleanImageFolder();
        }

        private void FormMapCopy_SizeChanged(object sender, EventArgs e)
        {
            //            pictureBox1.SetBounds(-1,30,this.Size.Width - 4 ,this.Size.Height - 4);
            Size tempSize = mapviewer.pictureBox.Size;
            tempSize.Width = this.Size.Width;
            tempSize.Height = this.Size.Height;
            mapviewer.pictureBox.Size = tempSize;
        }

        private void butZoomIn_Click(object sender, EventArgs e)
        {
            mapviewer.Zoom(2);
        }

        private void butZoomOut_Click(object sender, EventArgs e)
        {
            mapviewer.Zoom(0.5);
        }

        private void butUp_Click(object sender, EventArgs e)
        {
            mapviewer.LevelUp();
        }

        private void butDown_Click(object sender, EventArgs e)
        {
            mapviewer.LevelDown();
        }
    }
}
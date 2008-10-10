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
using System.Runtime.CompilerServices;

namespace ComboServer
{
   public class Protocol
    {
        static public string sd = "01";
        static public string exori_con = "02";
        static public string exori_hur = "03";
        static public string exori_gran = "04";
        static public string uh = "05";
        BListController blist;
        //string str = "<INFO><SELF><NAME>Grazy Mos</NAME><MAGICLVL>6</MAGICLVL><LVL>119</LVL><HP>1600</HP><HPPER>100</HPPER><X>1</X><Y>1</Y><Z>6</Z><SKILL></SKILL></SELF><TARGET><NAME>Klown</NAME><HPPER>100</HPPER></TARGET><TARGET><NAME>Tellytubby</NAME><HPPER>100</HPPER><X>1</X><Y>1</Y><Z>6</Z><MANASHIELD>?</MANASHIELD></TARGET></INFO>";
        //1 = sd
        //2 = exori con
        //3 = exori hur
        //4 = exori gran
        //5 = uh
        //String die verstuurd wordt ziet er zo uit: "Actie=1;Player=Grazy mos"
        public Protocol( BListController blist)
        {
            this.blist = blist;
        }

       public static int getStatus(ArrayList value, int switchcase)
       {
           if(switchcase ==1)
           {
                switch ((string)value[1])
                {
                    case "Sorcerer":
                    case "Druid":
                    case "Mage":
                        return 5;
                    case "MasterSorcerer":
                    case "ElderDruid":
                        return 4;
                    case "Knight":
                    case "EliteKnight":
                        return 6;
                    case "Paladin":
                    case "RoyalPaladin":
                        return 7;
                    case "unknow":
                        return -1;
                }
           }
           else if (switchcase == 2)
           {
               switch ((string)value[1])
               {
                   case "Mage":
                       return 1;
                   case "Paladin":
                       return 2;
                   case "Knight":
                       return 3;
               }
           }
           return -1;
       }

        public static string MaakCommandoRadar(String strActie, ArrayList alHitlist, ArrayList alHealList, int noobchar)
        {
            String strMessage = "Actie=03;<actie3>";
            for (int i = 0; i < alHitlist.Count; i++)
            {
                ArrayList value = (ArrayList)alHitlist[i];
                int stuff = Convert.ToInt32(value[9]);
                if (stuff >= 0 && stuff<=300)
                {
                    strMessage += "<player><name>" + value[0] + "</name>";
                    strMessage += "<status>" + getStatus(value, 1) + "</status>";
                    string xyz = (string)value[6];
                    string[] splitxyz = xyz.Split(',');
                    string x = splitxyz[0];
                    string y = splitxyz[1];
                    string z = splitxyz[2];

                    strMessage += "<lox>" + x + "</lox>";
                    strMessage += "<loy>" + y + "</loy>";
                    strMessage += "<loz>" + z + "</loz>";
                    strMessage += "<timems>" + value[9] + "</timems></player>";
                }
            }

            for (int i = 0; i < alHealList.Count; i++)
            {
                ArrayList value = (ArrayList)alHealList[i];
                int stuff = Convert.ToInt32(value[9]);
                if (stuff >= 0 && stuff <= 300)
                {
                    strMessage += "<player><name>" + value[0] + "</name>";
                    if (Convert.ToInt16(value[2]) > noobchar)
                    {
                        strMessage += "<status>" + getStatus(value, 2) + "</status>";
                    }
                    else
                    {
                        strMessage += "<status>" + 0 + "</status>";
                    }
                    string xyz = (string)value[6];
                    string[] splitxyz = xyz.Split(',');
                    string x = splitxyz[0];
                    string y = splitxyz[1];
                    string z = splitxyz[2];

                    strMessage += "<lox>" + x + "</lox>";
                    strMessage += "<loy>" + y + "</loy>";
                    strMessage += "<loz>" + z + "</loz>";
                    strMessage += "<timems>" + value[9] + "</timems></player>";
                }
            }
            strMessage += "</actie3>;<END>";

            return strMessage;
        }

        public static string MaakCommando(string strActie, string strPlayer)
        {
            return "Actie="+strActie + ";Player="+ strPlayer + ";<END>";
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void handleInfo(string PstrInfo, int id)
        {
            PstrInfo = PstrInfo.Replace("\n", "");
            PstrInfo = PstrInfo.Replace("\r", "");
            XMLParser parser = new XMLParser();
            XMLElement mainelement = parser.ParseXML(PstrInfo);
            XMLElement currentelement = mainelement.getChild("SELF;NAME", true, 0);
            string strSelfName = currentelement.Value;
            currentelement = mainelement.getChild("SELF;MAGICLVL", true, 0);
            string strSelfMgcLvl = currentelement.Value;
            currentelement = mainelement.getChild("SELF;LVL", true, 0);
            string strLvl = currentelement.Value;
            currentelement = mainelement.getChild("SELF;HP", true, 0);
            string strHp = currentelement.Value;
            currentelement = mainelement.getChild("SELF;HPPER", true, 0);
            string strHpPer = currentelement.Value;
            currentelement = mainelement.getChild("SELF;XYZ", true, 0);
            string strxyz = currentelement.Value;
            currentelement = mainelement.getChild("SELF;SKILL", true, 0);
            string strskill = currentelement.Value;
            int i = 0;
            ArrayList targetList = new ArrayList();
            while ((currentelement = mainelement.getChild("TARGET", true, i)) != null)
            {
                ArrayList list = new ArrayList();
                for(int i2 = 0; i2 < currentelement.Elements.Length; i2++)
                {
                    XMLElement newElement = currentelement.Elements[i2];
                    list.Add(newElement.Value);
                }
                targetList.Add(list);
                i++;
            }
            blist.submitList(strSelfName, strLvl, strHp, strHpPer, strSelfMgcLvl, strxyz, strskill, targetList, id);
       }
    }
}

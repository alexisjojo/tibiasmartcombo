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
    class Calculations
    {

        public static int calulateCombodmg(ArrayList PalAttacker, string xyz)
        {
            int comboDamage = 0;
            for (int i = 0; i < PalAttacker.Count; i++)
            {
                ArrayList array = (ArrayList)PalAttacker[i];
                if (array[1].Equals("Sorcerer") || array[1].Equals("Druid") || array[1].Equals("Mage"))
                    comboDamage += Convert.ToInt32(1.5 * Convert.ToDouble(array[2]) + 2 * Convert.ToDouble(array[5]) + 13);
                else if (array[1].Equals("Paladin"))
                    comboDamage += Convert.ToInt32(1.5 * Convert.ToDouble(array[2]) + 2 * Convert.ToDouble(array[5]) + 13);
                else if (array[1].Equals("Knight"))
                {
                    string[] strA = ((string)array[6]).Split(',');
                    string[] strA2 = xyz.Split(',');
                    int skill = Convert.ToInt16((string)array[7]);
                    int sx = Convert.ToInt32(strA[0]);
                    int sy = Convert.ToInt32(strA[1]);
                    int sz = Convert.ToInt32(strA[2]);
                    int tx = Convert.ToInt32(strA2[0]);
                    int ty = Convert.ToInt32(strA2[1]);
                    int tz = Convert.ToInt32(strA2[2]);
                    int verschil = checkVerschil(sx, sy, sz, tx, ty, tz);
                    if (verschil > 1)
                    {
                        double exoriMinDmg = skill * 0.25 + 20;
                        double exoriMaxDmg = skill * 0.50 + 30;
                        int total = (int)(exoriMaxDmg + exoriMinDmg);
                        int exoriDmg = total / 2;
                        comboDamage += exoriDmg;
                    }
                    else if (verschil > 0)
                    {
                        double exoriMinDmg = skill * 1.5 + 40;
                        double exoriMaxDmg = skill * 2.0 + 60;
                        int total = (int)(exoriMaxDmg + exoriMinDmg);
                        int exoriDmg = total / 2;
                        comboDamage += exoriDmg;
                    }
                }
            }
            return comboDamage;
        }


        public static int checkVerschil(int sx, int sy, int sz, int tx, int ty, int tz)
        {
            int verschil = 0;


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

        public static bool checkEnemyShield(String vocation, string manashield)
        {
            switch (vocation)
            {
                case "Sorcerer":
                case "Druid":
                case "Mage":
                case "MasterSorcerer":
                case "ElderDruid":
                    if (manashield.Equals("?"))
                        return true;
                    else
                        return false;
                case "Knight":
                case "EliteKnight":
                case "Paladin":
                case "RoyalPaladin":
                    return false;
                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ArrayList calculateHP(ArrayList PAList)
        {
            for (int i = 0; i < PAList.Count; i++)
            {
                ArrayList array = (ArrayList)PAList[i];
                int hp = 0;
                switch ((string)array[1])
                {
                    case "Sorcerer":
                    case "Druid":
                    case "Mage":
                    case "MasterSorcerer":
                    case "ElderDruid":
                        hp = Convert.ToInt16(array[2]) * 5 + 145;
                        break;
                    case "Knight":
                    case "EliteKnight":
                        hp = Convert.ToInt16(array[2]) * 15 + 65;
                        break;
                    case "Paladin":
                    case "RoyalPaladin":
                        hp = Convert.ToInt16(array[2]) * 10 + 105;
                        break;
                    case "unknow":
                        hp = 200;
                        break;
                }
                array[3] = hp + "";
                PAList[i] = array;
            }
            return PAList;
        }

        public static int getMaxMana(String vocation, int level)
        {
            int mana = 0;
            switch (vocation)
            {
                case "Sorcerer":
                case "Druid":
                case "Mage":
                case "MasterSorcerer":
                case "ElderDruid":
                    mana = level * 30 - 205;
                    break;
                case "Knight":
                case "EliteKnight":
                    mana = level * 5 -5;
                    break;
                case "Paladin":
                case "RoyalPaladin":
                    mana = level * 15 - 85;
                    break;
                case "unknow":
                    mana = 200;
                    break;
            }
            return mana;
        }
    }
}

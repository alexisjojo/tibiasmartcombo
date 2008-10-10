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
using Tibia.Objects;

namespace ComboClient
{
    class Protocol
    {

        public static string BattleListToString(List<Creature> PbList, Player player, bool manashield, int skill)
        {
            String str = "<INFO><SELF><NAME>" + player.Name + "</NAME>" + "<MAGICLVL>" + player.MagicLevel + "</MAGICLVL><LVL>" + player.Level + "</LVL><HP>" + player.HP + "</HP><HPPER>" + player.HPBar + "</HPPER><XYZ>" + player.X + "," + player.Y + "," + player.Z + "</XYZ><SKILL>" + skill  +"</SKILL></SELF>";
            for (int i = 0; i < PbList.Count; i++)
            {
                Creature creature = PbList[i];
                int id = player.Target_ID;
                if ((creature.Type == Tibia.Constants.CreatureType.Target || creature.Type == Tibia.Constants.CreatureType.Player) && creature.IsVisible)    
                {
                    str += "<TARGET><NAME>" + creature.Name + "</NAME>" + "<HPPRE>" + creature.HPBar + "</HPPRE><XYZ>" + creature.X + "," + creature.Y + "," + creature.Z + "</XYZ>";
                    if (manashield && creature.Id == id)
                        str += "<MANASHIELD>GEEN</MANASHIELD>";
                    else
                        str += "<MANASHIELD>?</MANASHIELD>";
                    str += "</TARGET>";
                }
            }
            str += "</INFO>";
            return str;
        }
    }
}

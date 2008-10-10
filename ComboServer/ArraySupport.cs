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

namespace ComboServer
{
    class ArraySupport
    {

        public static int getValueFromArray(ArrayList PAL, string PstrNaam, int intMaxSearch)
        {
            for (int i = 0; i < PAL.Count; i++)
            {
                ArrayList array = (ArrayList)PAL[i];
                if (intMaxSearch <= 0)
                {
                    intMaxSearch = array.Count;
                }
                for (int i2 = 0; i2 < intMaxSearch; i2++)
                {
                    string str = (string)array[i2];
                    if (str.Equals(PstrNaam))
                        return i;
                }
            }
            return -1;
        }

        public static int getValueFromArray(ArrayList PAL, string PstrNaam)
        {
            for (int i = 0; i < PAL.Count; i++)
            {
                string str = (string)PAL[i];
                string[] strA = str.Split(',');
                if (strA[0].Equals(PstrNaam))
                    return i;
            }
            return -1;
        }

    }
}

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
using System.IO;

namespace ComboClient
{
    class IniReader
    {

        public void WriteFile(string file, string text)
        {
            StreamWriter streamwriter = new StreamWriter(file);
            streamwriter.Write(text);
            streamwriter.Close();
        }

        public Hashtable ReadFile(string file)
        {
            Hashtable hashSettings = new Hashtable();
            StreamReader streamReader = new StreamReader(file);
            String strCurrentLine = "";
            while ((strCurrentLine = streamReader.ReadLine()) != null)
            {
                if (strCurrentLine.Contains("[") && strCurrentLine.Contains("]"))
                    Read(ref streamReader, ref hashSettings);
            }
            System.Console.WriteLine("Ini File Parsed");
            streamReader.Close();
            return hashSettings;
        }

        private void Read(ref StreamReader streamReader, ref Hashtable hashSettings)
        {
            String strCurrentLine = "";
            while ((strCurrentLine = streamReader.ReadLine()) != null && !strCurrentLine.Contains("[/") && !strCurrentLine.Contains("]"))
            {
                String[] strAObjects = strCurrentLine.Split('=');
                if (strAObjects.Length == 2)
                {
                    hashSettings.Add(strAObjects[0], strAObjects[1]);
                }
            }
        }
    }
}

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

namespace ComboServer
{
    class XMLParser
    {
        private XMLElement currentelement;
        private bool firstelement = true;

        public XMLElement ParseXML(string xmlString)
        {
            if (EnableParse(xmlString))
            {
                while (xmlString != "")
                {
                    if (xmlString.StartsWith("<"))
                        ParseTag(ref xmlString);
                    else if (xmlString.StartsWith("\r") || xmlString.StartsWith("\n") || xmlString.StartsWith("\t"))
                        RemoveBreaks(ref xmlString);
                    else
                        GetValue(ref xmlString);
                }

            }
            return currentelement;
        }

        private void GetValue(ref String xmlString)
        {
            int endpos = xmlString.IndexOf("<");
            string value = xmlString.Substring(0, endpos);
            while (value.EndsWith("\r") || value.EndsWith("\n") || value.EndsWith("\t"))
                value = value.Substring(0, value.Length - 1);
           // System.Console.WriteLine(value);
            currentelement.Value = value;
            xmlString = xmlString.Substring(endpos);
        }

        private void ParseTag(ref String xmlString)
        {
            int endpos = xmlString.IndexOf(">");
            string tagname = xmlString.Substring(1, endpos - 1);
           // System.Console.WriteLine(tagname);
            if (!xmlString.StartsWith("</"))
            {
                if (firstelement)
                {
                    currentelement = new XMLElement(tagname, "", null, null, null);
                    firstelement = false;
                }
                else
                {
                    currentelement.AddChild(new XMLElement(tagname, "", null, null, currentelement));
                    XMLElement[] elements = currentelement.getChilds(false);
                    currentelement = elements[elements.Length - 1];
                }
            }
            else
            {
                if (currentelement.HasParent)
                    currentelement = currentelement.Parent;
            }
            xmlString = xmlString.Substring(endpos + 1);
        }

        private void RemoveBreaks(ref String xmlString)
        {
            while (xmlString.StartsWith("\r") || xmlString.StartsWith("\n") || xmlString.StartsWith("\t"))
            {
                xmlString = xmlString.Substring(1);
            }
          //  System.Console.WriteLine(xmlString);
        }

        private bool EnableParse(string xmlString)
        {
            String[] test = xmlString.Split('<');
            int endtags = 0;
            string substring = xmlString;
            while (substring.Contains("</"))
            {
                substring = substring.Substring(substring.IndexOf("</") + 2);
                endtags++;
            }
            if ((test.Length - 1) / endtags == 2 && xmlString.StartsWith("<") && xmlString.EndsWith(">"))
                return true;
            else
                return false;
        }
    }
}

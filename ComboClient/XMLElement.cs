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

namespace ComboClient
{
    class XMLElement
    {
        private string tagname = "";
        private string value = "";
        private Hashtable parameter;
        private ArrayList elements;
        private XMLElement parent;

        public XMLElement(string tagname, string value, Hashtable parameter, ArrayList elements, XMLElement parent)
        {
            this.tagname = tagname;
            this.value = value;
            this.parent = parent;
            if (parameter != null)
                this.parameter = parameter;
            else
               parameter = new Hashtable();
            if (elements != null)
                this.elements = elements;
            else
                this.elements = new ArrayList();
        }

        public void AddChild(XMLElement element)
        {
            if (element != null)            //afschermen dat je geen lege elementen mag toevoegen
            {
                 elements.Add(element);
            }
        }

        public string TagName
        {
            get { return this.tagname; }
        }

        public string Value
        {
            get { return this.value; }
            set 
            { 
                if (this.value == "")
                    this.value = value;
            }
        }

        public Hashtable Parameter
        {
            get { return this.parameter; }
        }

        public XMLElement[] Elements
        {
            get 
            {
                XMLElement[] xmlElements = new XMLElement[elements.Count];
                for (int i = 0; i < elements.Count; i++)
                {
                    xmlElements[i] = (XMLElement)elements[i];
                }
                return xmlElements; 
            }
        }

        //TODO: eventueel functionaliteit toevoegen dat er dieper dan 1 laag mag worden gezocht
        public XMLElement getChild(string tagname, bool verydeep, int childpos)
        {
            XMLElement[] allchilds = getChilds(tagname, true);
            if (childpos >= allchilds.Length)
                return null;
            else
                return allchilds[childpos];
        }

        //Functie voor het opzoeken van alle tags met de meegegeven tagname.
        public XMLElement[] getChilds(string tagname, bool verydeep)
        {
            //begin met het opzoeken van alle elementen die de meegegeven tagname bevatten.
            ArrayList xmlElements = new ArrayList();
            XMLElement currentelement;
            for (int i = 0; i < elements.Count; i++)    // ga alle tags binnen deze klasse langs
            {
                currentelement = (XMLElement)elements[i];
                if (currentelement.TagName.StartsWith(tagname))     //als de opgegeven naam overeenkomt dan toevoegen in de lijst om terug te geven.
                    xmlElements.Add(currentelement);
                if (verydeep)
                {
                    int nexttagpos = tagname.IndexOf(";");
                    tagname = tagname.Substring(nexttagpos + 1);
                    currentelement.getChilds(ref xmlElements, tagname);
                }
            }
            //Begin nu met het omzetten van alle arraylist resultaten naar een XMLElement array
            XMLElement[] resultXmlElements = new XMLElement[xmlElements.Count];
            for (int i = 0; i < xmlElements.Count; i++)
            {
                resultXmlElements[i] = (XMLElement)xmlElements[i];
            }
            return resultXmlElements;
        }

        //Functie voor het opzoeken van alle tags met de meegegeven tagname.
        //Deze functie is private omdat die alleen wordt aangeroepen wanneer er diep moet worden gezocht naar kinderen.
        private void getChilds(ref ArrayList xmlElements, string tagname)
        {
            //begin met het opzoeken van alle elementen die de meegegeven tagname bevatten.
            XMLElement currentelement;
            for (int i = 0; i < elements.Count; i++)    // ga alle tags binnen deze klasse langs
            {
                currentelement = (XMLElement)elements[i];
                if (currentelement.TagName.Equals(tagname))     //als de opgegeven naam overeenkomt dan toevoegen in de lijst om terug te geven.
                    xmlElements.Add(currentelement);
                //zoek de volgende tagnaam op
                int nexttagpos = tagname.IndexOf(";");
                tagname = tagname.Substring(nexttagpos + 1);
                currentelement.getChilds(ref xmlElements, tagname);
            }
        }

        //Functie voor het opzoeken van alle tags.
        public XMLElement[] getChilds(bool verydeep)
        {
            //begin met het opzoeken van alle elementen die de meegegeven tagname bevatten.
            ArrayList xmlElements = new ArrayList();
            XMLElement currentelement;
            for (int i = 0; i < elements.Count; i++)    // ga alle tags binnen deze klasse langs
            {
                currentelement = (XMLElement)elements[i];
                xmlElements.Add(currentelement);
                if (verydeep)
                    currentelement.getChilds(ref xmlElements);
            }
            //Begin nu met het omzetten van alle arraylist resultaten naar een XMLElement array
            XMLElement[] resultXmlElements = new XMLElement[xmlElements.Count];
            for (int i = 0; i < xmlElements.Count; i++)
            {
                resultXmlElements[i] = (XMLElement)xmlElements[i];
            }
            return resultXmlElements;
        }

        //Functie voor het opzoeken van alle tags met de meegegeven tagname.
        //Deze functie is private omdat die alleen wordt aangeroepen wanneer er diep moet worden gezocht naar kinderen.
        private void getChilds(ref ArrayList xmlElements)
        {
            //begin met het opzoeken van alle elementen die de meegegeven tagname bevatten.
            XMLElement currentelement;
            for (int i = 0; i < elements.Count; i++)    // ga alle tags binnen deze klasse langs
            {
                currentelement = (XMLElement)elements[i];
                xmlElements.Add(currentelement);
                currentelement.getChilds(ref xmlElements, tagname);
            }
        }

        public XMLElement Parent
        {
            get { return parent; }
        }

        public bool HasParent
        {
            get { return parent != null; }
        }

        public bool HasChield
        {
            get { return elements.Count > 0; }
        }
    }
}

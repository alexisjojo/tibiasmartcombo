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
    class Protectionzones
    {
        //contains string: "x,y,z"
        private ArrayList protectionzones;
        private bool ot;

        public Protectionzones(bool ot)
        {
            this.ot = ot;
            protectionzones = new ArrayList();
            addAll();
        }

        public bool inPz(string pstr)
        {
            if(protectionzones.Contains(pstr))
                return true;
            return false;
        }

        public void addAll()
        {
            if (!ot)
            {
                protectionzones = addPorthope(protectionzones);
                protectionzones = addCarlin(protectionzones);

                protectionzones = addron(protectionzones);
                protectionzones = addFemor(protectionzones);
                protectionzones = addAnkrahmun(protectionzones);
                protectionzones = addLibertybay(protectionzones);
                protectionzones = addDarashia(protectionzones);
            }
        }

        #region carlin;

        public ArrayList addCarlin(ArrayList add)
        {
            add = CarlinDepot(add);
            add = CarlinTempel(add);
            add = CarlinBoat(add);
            add = CarlinBlessings(add);
            return add;
        }

        public ArrayList CarlinDepot(ArrayList list)
        {
            list = add(list, 32326, 32343, 31776, 31784, 8);
            list = add(list, 32326, 32329, 31776, 31784, 8);
            list = add(list, 32332, 32340 , 31778, 31788 , 7);
            return list;
        }

        public ArrayList CarlinTempel(ArrayList list)
        {
            list = add(list, 32357, 32363, 31777, 31788, 7);
            return list;
        }

        public ArrayList CarlinBoat(ArrayList list)
        {
            list = add(list, 32393, 32382, 31819, 31823, 6);
            list = add(list, 32393, 32382, 31819, 31823, 7);
            return list;
        }

        public ArrayList CarlinBlessings(ArrayList list)
        {
            list = add(list, 32356, 32361, 31682, 31691, 7);
            return list;
        }

        #endregion

        #region port hope;

        public ArrayList addPorthope(ArrayList add)
        {
            add = PortHopeBoat(add);
            return add;
        }

        public ArrayList PortHopeBoat(ArrayList list)
        {
            list = add(list, 32523, 32538, 32787, 32781, 6);
            return list;
        }

        #endregion

        #region edron;

        public ArrayList addron(ArrayList add)
        {
            add = EdronBoat(add);
            add = EdronCarpet(add);
            return add;
        }

        public ArrayList EdronBoat(ArrayList list)
        {
            list = add(list, 33185, 33169, 31762, 31767, 6);
            return list;
        }
        public ArrayList EdronCarpet(ArrayList list)
        {
            list = add(list, 33191, 33195, 31782, 31785, 3);
            return list;
        }

        #endregion

        #region femor;

        public ArrayList addFemor(ArrayList add)
        {
            add = FemorCarpet(add);
            return add;
        }
        public ArrayList FemorCarpet(ArrayList list)
        {
            list = add(list, 32534, 32538, 31835, 31838, 4);
            return list;
        }
        #endregion

        #region ankrahmun;

        public ArrayList addAnkrahmun(ArrayList add)
        {
            add = AnkrahmunBoat(add);
            add = AnkrahmunDp(add);
            return add;
        }
        public ArrayList AnkrahmunBoat(ArrayList list)
        {
            list = add(list, 33088, 33095, 32891, 33095, 6);
            return list;
        }
        public ArrayList AnkrahmunDp(ArrayList list)
        {
            list = add(list, 33119, 33134, 32851, 32836, 7);
            return list;
        }
        #endregion

        #region liberty bay;

        public ArrayList addLibertybay(ArrayList add)
        {
            add = LibertybayBoat(add);
            return add;
        }
        public ArrayList LibertybayBoat(ArrayList list)
        {
            list = add(list, 32281, 32288, 32899, 32288, 6);
            return list;
        }
        #endregion

        #region darashia;

        public ArrayList addDarashia(ArrayList add)
        {
            add = DarashiaCarpet(add);
            add = DarashiaBoat(add);
            add = DarashiaDp(add);
            add = DarashiaSwim(add);
            return add;
        }

        public ArrayList DarashiaCarpet(ArrayList list)
        {
            list = add(list, 33268, 33272, 32439, 32442, 6);
            return list;
        }

        public ArrayList DarashiaBoat(ArrayList list)
        {
            list = add(list, 33295, 33284, 32478, 32483, 6);
            return list;
        }

        public ArrayList DarashiaDp(ArrayList list)
        {
            list = add(list, 33215, 33212, 32452, 32455, 7);
            return list;
        }
        public ArrayList DarashiaSwim(ArrayList list)
        {
            list = add(list, 33231, 33246, 32512, 32504, 7);
            list = add(list, 33246, 33235, 32504, 32500, 7);
            list = add(list, 33246, 33237, 32504, 32497, 7);
            list = add(list, 33238, 33240, 32496, 32496, 7);
            return list;
        }

        #endregion

        public ArrayList add(ArrayList add, int Px, int Px2, int Py, int Py2, int Pz)
        {
            if (Px > Px2)
            {
                int buf = Px;
                Px = Px2;
                Px2 = buf;
            }
            if (Py > Py2)
            {
                int buf = Py;
                Py = Py2;
                Py2 = buf;
            }
            for (int x = Px; x < Px2; x++)
                for (int y = Py; y < Py2; y++)
                {
                    string str = x + "," + y + "," + Pz;
                    add.Add(str);
                }
            return add;
        }


    }
}

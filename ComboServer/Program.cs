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
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ComboServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }

      /* public Program()
        {
           bool exit = false;
            bool worldset = false;

            do
            {
                System.Console.ForegroundColor = ConsoleColor.White;
                if (!worldset)
                {
                    Console.WriteLine("World:");
                    String world = Console.ReadLine();
                    worldset = true;
                    Console.WriteLine("Press a key to continue!");
                    server = Socketserver.Instance(5555, world);
                }
                cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        server.connect();
                        break;
                    case ConsoleKey.D:
                        server.CloseSockets();
                        break;
                    case ConsoleKey.H:
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("Press 'C' to start listening");
                        System.Console.WriteLine("Press 'D' to stop listening");
                        System.Console.WriteLine("Press 'U' to reload the targetlist");
                        break;
                    case ConsoleKey.U:
                        server.blist.updateEnemys();
                        System.Console.WriteLine("Updating list");
                        break;
                    default:
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("Press h for help");
                        break;

                }

            }
            while (cki.Key != ConsoleKey.Escape && !exit);
        }*/
    }
}

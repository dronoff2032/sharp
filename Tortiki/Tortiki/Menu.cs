using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortiki
{
    internal class Menu
    {
        public static int menu(int max)
        {
            int y = 2;
            while (true)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine("->");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && y < max)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine("  ");
                    y++;
                }
                else if (key.Key == ConsoleKey.UpArrow && y > 2)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine("  ");
                    y--;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return y;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    internal class Menu
    {
        public static int show(int min_y, int max_y)
        {
            int y = min_y;

            while (true)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine(">>");

                ConsoleKeyInfo key = Console.ReadKey();

                Console.SetCursorPosition(0, y);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && y != min_y)
                {
                    y--;
                }
                else if (key.Key == ConsoleKey.DownArrow && y != max_y + min_y)
                {
                    y++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return y - min_y;
                }
            }

        }
    }
}

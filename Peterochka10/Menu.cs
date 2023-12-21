using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peterochka10
{
    internal class Menu
    {
        public static int Show(int min, int max, int startpos)
        {
            int pos = startpos;

            while (true)
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("-> ");

                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.UpArrow && pos != min)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("   ");
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != max)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("   ");
                    pos++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    return 100;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    return 200;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    return 300;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return 1000;
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    return 2000;
                }
            }

            return pos;
        }
    }
}

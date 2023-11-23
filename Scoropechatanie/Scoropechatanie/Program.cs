using System.Diagnostics;

namespace Scoropechatanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string username = Console.ReadLine();

            while (true)
            {
                Console.Clear();

                string text = "Главная идея слепой печати в том, что за каждым пальцем закреплена своя зона клавиш. Это позволяет печатать, не глядя на клавиатуру. Регулярно тренируйтесь и, благодаря мышечной памяти, все ваши десять пальцев будут знать, куда нажать.";

                int pos_x = 0;
                int pos_y = 0;

                float symbols = 0;

                Console.WriteLine(text);
                Console.WriteLine();


                Thread thread = new Thread(_ =>
                {
                    int seconds = 60;

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    for (int i = 0; i <= 60; i++)
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine(seconds);
                        Thread.Sleep(1000);
                        seconds--;
                    }

                    stopWatch.Stop();

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("Стоп!");
                    Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
                });

                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Как только будете готовы - нажмите Enter.");

                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.Enter);

                Console.SetCursorPosition(0, 3);
                Console.WriteLine("                                             ");


                thread.Start();


                foreach (char c in text)
                {
                    while (thread.IsAlive)
                    {
                        char user_c = Console.ReadKey(true).KeyChar;

                        if (pos_x == 120)
                        {
                            pos_x = 0;
                            pos_y = pos_y + 1;
                        }

                        if (user_c == c)
                        {
                            Console.SetCursorPosition(pos_x, pos_y);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(user_c);
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 3);
                            pos_x++;
                            symbols++;

                            break;
                        }
                    }
                }
                
                thread.Interrupt();

                Console.Clear();

                Console.WriteLine("Имя - " + username + ", Символов в минуту: " + symbols / 1 + " Символов в секунду: " + symbols / 60);
                Thread.Sleep(2000);

                Console.WriteLine("Если хотите попробовать еще, нажмите Enter.");

                do
                {
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.Enter);
            }

            /*      TableRecordType record = new TableRecordType();
                  record.name = username;
                  record.symbols_in_minute = symbols / 1;
                  record.symbols_in_second = symbols / 60;

                  Records.new_result(username, record);
                  Records.records();*/
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Peterochka10.Login;

namespace Peterochka10
{
    internal class Bughalter : ICrud
    {
        public static void show()
        {
            while (true)
            {
                Console.Clear();

                while (true)
                {
                    Console.WriteLine("         Добро пожаловать, " + Login.login + "!" + "                 Роль: " + Login.userRole);
                    Console.WriteLine("--------------------------------------------------------------------|--------------------------------------------------");
                    Console.WriteLine("ID, название, сумма, дата, тип операции                             |   F1 - Добавить запись. F2 - Найти запись.");

                    List<Bughalteria> bughalteria = readBughalteria();
                    for (int i = 0; i < bughalteria.Count; i++)
                    {
                        Console.WriteLine("   " + bughalteria[i].Id + ", " + bughalteria[i].Name + ", " + bughalteria[i].Date + ", " + bughalteria[i].Type);
                    }

                    int choose = Menu.Show(3, bughalteria.Count + 2, 3);

                    if (choose <= bughalteria.Count + 2)
                    {
                        edit(bughalteria[choose - 3]);
                    }
                    else if (choose == 1000)
                    {
                        Console.Clear();
                        Login.loginn();
                    }
                }
            }
        }

        public static void edit(Bughalteria bughalteria)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("         Добро пожаловать, " + Login.login + "!" + "                 Роль: " + Login.userRole);
                Console.WriteLine("--------------------------------------------------------------------|--------------------------------------------------");
                Console.WriteLine("Редактирование пользователя                                         |   ESC - Выйти в меню. DEL - Удалить запись.");

                Console.WriteLine("   ID:" + bughalteria.Id);
                Console.WriteLine("   Название:" + bughalteria.Name);
                Console.WriteLine("   Дата:" + bughalteria.Date);
                Console.WriteLine("   Тип перевода:" + bughalteria.Type);

                int choose = Menu.Show(3, 6, 3);

                if (choose == 3)
                {
                    bughalteria.Id = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(6, 3);

                    bughalteria.Id += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 4)
                {
                    bughalteria.Name = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(9, 4);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            bughalteria.Name += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && bughalteria.Name.Length != 0)
                        {
                            Console.SetCursorPosition(10 + bughalteria.Name.Length - 1, 0);
                            Console.Write(" ");
                            bughalteria.Name = bughalteria.Name.Remove(bughalteria.Name.Length - 1);
                            Console.SetCursorPosition(10 + bughalteria.Name.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 5)
                {
                    bughalteria.Date = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 5);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            bughalteria.Date += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && bughalteria.Date.Length != 0)
                        {
                            Console.SetCursorPosition(10 + bughalteria.Date.Length - 1, 0);
                            Console.Write(" ");
                            bughalteria.Date = bughalteria.Date.Remove(bughalteria.Type.Length - 1);
                            Console.SetCursorPosition(10 + bughalteria.Date.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 6)
                {
                    bughalteria.Type = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 6);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            bughalteria.Type += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && bughalteria.Type.Length != 0)
                        {
                            Console.SetCursorPosition(10 + bughalteria.Type.Length - 1, 0);
                            Console.Write(" ");
                            bughalteria.Type = bughalteria.Type.Remove(bughalteria.Type.Length - 1);
                            Console.SetCursorPosition(10 + bughalteria.Type.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }

                else if (choose == 1000)
                {

                    Console.Clear();
                    break;
                }
                else if (choose == 2000)
                {
                    Console.Clear();
                    break;
                }
            }

        }

        public static List<Bughalteria> readBughalteria()
        {
            string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "bughalteria.json"));
            List<Bughalteria> result = JsonConvert.DeserializeObject<List<Bughalteria>>(text);
            return result;
        }

        public static void newProduct(Bughalteria bughalteria)
        {
            List<Bughalteria> result = readBughalteria();
            result.Add(bughalteria);
            string json = JsonConvert.SerializeObject(result);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "bughalteria.json"), json);
        }

        public void Create()
        {

        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

    }
}

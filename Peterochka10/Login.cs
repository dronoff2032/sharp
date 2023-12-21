using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Peterochka10
{
    internal class Login
    {
        public enum roles
        {
            Administrator,
            HRManager,
            StorageManager,
            Cashier,
            Bughatler
        }

        public static string login = "";
        public static string password = "";
        public static string userRole = "";
        public static void loginn()
        {
            login = "";
            password = "";
            userRole = "";

            int choose = 0;

            Console.WriteLine("   Логин: ");
            Console.WriteLine("   Пароль: ");
            Console.WriteLine("   Авторизоваться");

            while (true)
            {
                choose = Menu.Show(0, 2, choose);

                if (choose == 0)
                {
                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 0);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            login += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && login.Length != 0)
                        {
                            Console.SetCursorPosition(10 + login.Length - 1, 0);
                            Console.Write(" ");
                            login = login.Remove(login.Length - 1);
                            Console.SetCursorPosition(10 + login.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 1)
                {
                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(11, 1);

                    do
                    {
                        key = Console.ReadKey(true);
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter)
                        {
                            password += key.Key.ToString();
                            Console.Write("*");
                        }
                        else if (key.Key == ConsoleKey.Backspace && login.Length != 0)
                        {
                            Console.SetCursorPosition(10 + login.Length - 1, 0);
                            Console.Write(" ");
                            login = login.Remove(login.Length - 1);
                            Console.SetCursorPosition(10 + login.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 2)
                {
                    List<User> allUsers = readUsers();

                    for (int i = 0; i < allUsers.Count; i++)
                    {
                        if (allUsers[i].login == login && allUsers[i].password == password) {
                            userRole = Enum.GetNames(typeof(roles))[allUsers[i].role];
                            
                            if (userRole == roles.Administrator.ToString())
                            {
                                Administrator.show();
                            } else if (userRole == roles.HRManager.ToString())
                            {
                                HRManager.show();
                            }
                            else if (userRole == roles.StorageManager.ToString())
                            {
                                StorageManager.show();
                            }
                            else if (userRole == roles.Cashier.ToString())
                            {
                                Cashier.show();
                            }
                            else if (userRole == roles.Bughatler.ToString())
                            {
                                Bughalter.show();
                            }

                        }   
                    }

                    Console.WriteLine("Неправильный логин или пароль");
                    Console.ReadLine();

                    login = "";
                    password = "";
                    Console.Clear();
                    break;
                }

            }

        }

        public static List<User> readUsers()
        {
            string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "users.json"));
            List<User> result = JsonConvert.DeserializeObject<List<User>>(text);
            return result;
        }

        public static void newUser(User newUser)
        {
            List<User> result = readUsers();
            result.Add(newUser);
            string json = JsonConvert.SerializeObject(result);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "users.json"), json);
        }
    }
}

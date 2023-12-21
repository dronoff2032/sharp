using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Peterochka10.Login;

namespace Peterochka10
{
    internal class Administrator : ICrud
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
                    Console.WriteLine("ID, Логин, Пароль, Роль                                             |   F1 - Добавить запись. F2 - Найти запись.");

                    List<User> users = Login.readUsers();
                    for (int i = 0; i < users.Count; i++)
                    {
                        Console.WriteLine("   " + users[i].id + ", " + users[i].login + ", " + users[i].password + ", " + Enum.GetNames(typeof(Login.roles))[users[i].role]);
                    }

                    int choose = Menu.Show(3, users.Count + 2, 3);

                    if (choose <= users.Count + 2)
                    {
                        edit(users[choose - 3]);
                    } 
                    else if (choose == 1000)
                    {
                        Console.Clear();
                        Login.loginn();
                    } else if (choose == 100)
                    {
                        Console.Clear();

                        User newUser = new User();

                        Console.Write("Введите имя пользователя: ");
                        newUser.login = Console.ReadLine().ToUpper();

                        Console.Write("Введите пароль: ");
                        newUser.password = Console.ReadLine().ToUpper();

                        Console.Write("Введите роль: ");
                        newUser.role = Convert.ToInt32(Console.ReadLine());

                        Login.newUser(newUser);

                        Console.Clear();
                    }
                }
            }
        }

        public static void edit(User user)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("         Добро пожаловать, " + Login.login + "!" + "                 Роль: " + Login.userRole);
                Console.WriteLine("--------------------------------------------------------------------|--------------------------------------------------");
                Console.WriteLine("Редактирование пользователя                                         |   ESC - Выйти в меню. DEL - Удалить запись.");

                Console.WriteLine("   ID:" + user.id);
                Console.WriteLine("   Логин:" + user.login);
                Console.WriteLine("   Пароль:" + user.password);
                Console.WriteLine("   Роль:" + user.role + " - " + Enum.GetNames(typeof(Login.roles))[user.role]);

                int choose = Menu.Show(3, 6, 3);

                if (choose == 3)
                {
                    user.id = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(6, 3);

                    user.id += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 4)
                {
                    user.login = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(9, 4);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            user.login += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && user.login.Length != 0)
                        {
                            Console.SetCursorPosition(10 + user.login.Length - 1, 0);
                            Console.Write(" ");
                            user.login = user.login.Remove(user.login.Length - 1);
                            Console.SetCursorPosition(10 + user.login.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 5)
                {
                    user.password = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 5);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            user.password += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && user.password.Length != 0)
                        {
                            Console.SetCursorPosition(10 + user.password.Length - 1, 0);
                            Console.Write(" ");
                            user.password = user.password.Remove(user.password.Length - 1);
                            Console.SetCursorPosition(10 + user.password.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                } else if (choose == 6)
                {
                    user.role = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(8, 6);

                    user.role += Convert.ToInt32(Console.ReadLine());
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

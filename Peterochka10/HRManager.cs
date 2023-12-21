using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peterochka10
{
    internal class HRManager
    {
        public static void show()
        {
            while (true)
            {
                Console.Clear();

                while (true)
                {
                    int choose;

                    Console.WriteLine("         Добро пожаловать, " + Login.login + "!" + "                 Роль: " + Login.userRole);
                    Console.WriteLine("--------------------------------------------------------------------|--------------------------------------------------");
                    Console.WriteLine("ID, Фамилия, Имя, Отчество, Дата рождения, Паспорт, Роль, Зарплата  |   F1 - Добавить запись. F2 - Найти запись.");

                    List<Employee> employees = readEmployees();
                    if (employees != null)
                    {
                        for (int i = 0; i < employees.Count; i++)
                        {
                            Console.WriteLine("   " + employees[i].Id + ", " + employees[i].SecondName + ", " + employees[i].Name + ", " + employees[i].Surname + ", " + employees[i].BirthDate + ", " + employees[i].Passport + ", " + employees[i].Salary + ", " + employees[i].UserId + ", " + Enum.GetNames(typeof(Login.roles))[employees[i].Role]);
                        }

                        choose = Menu.Show(3, employees.Count + 2, 3);

                        if (choose <= employees.Count + 2)
                        {
                            edit(employees[choose - 3]);
                        }
                    } else
                    {
                        choose = Menu.Show(3, 3, 3);
                    }

                    if (choose == 1000)
                    {
                        Console.Clear();
                        Login.loginn();
                    }
                    else if (choose == 100)
                    {
                        Console.Clear();

                        Employee newEmployee = new Employee();

                        Console.Write("Введите ID: ");
                        newEmployee.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите фамилию: ");
                        newEmployee.SecondName = Console.ReadLine();

                        Console.Write("Введите имя: ");
                        newEmployee.Name = Console.ReadLine();

                        Console.Write("Введите отчество: ");
                        newEmployee.Surname = Console.ReadLine();

                        Console.Write("Введите дату рождения: ");
                        newEmployee.BirthDate = Console.ReadLine();

                        Console.Write("Введите пасспортные данные: ");
                        newEmployee.Passport = Console.ReadLine();

                        Console.Write("Введите роль: ");
                        newEmployee.Role = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите зарплату: ");
                        newEmployee.Salary = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите пользователя: ");
                        newEmployee.UserId = Convert.ToInt32(Console.ReadLine());

                        newEmployeee(newEmployee);

                        Console.Clear();
                    }
                }
            }
        }

        public static void edit(Employee employee)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("         Добро пожаловать, " + Login.login + "!" + "                 Роль: " + Login.userRole);
                Console.WriteLine("--------------------------------------------------------------------|--------------------------------------------------");
                Console.WriteLine("Редактирование сотрудников                                         |   ESC - Выйти в меню. DEL - Удалить запись.");

                Console.WriteLine("   ID:" + employee.Id);
                Console.WriteLine("   Фамилия:" + employee.SecondName);
                Console.WriteLine("   Имя:" + employee.Name);
                Console.WriteLine("   Отчество:" + employee.Surname);
                Console.WriteLine("   Дата рождения:" + employee.BirthDate);
                Console.WriteLine("   Паспорт:" + employee.Passport);
                Console.WriteLine("   Запралта:" + employee.Salary);
                Console.WriteLine("   ID пользователя:" + employee.UserId);
                Console.WriteLine("   Роль: " + employee.Role + " - " + Enum.GetNames(typeof(Login.roles))[employee.Role]);

                int choose = Menu.Show(3, 11, 3);

                if (choose == 3)
                {
                    employee.Id = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(6, 3);

                    employee.Id += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 4)
                {
                    employee.SecondName = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(9, 4);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            employee.SecondName += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && employee.SecondName.Length != 0)
                        {
                            Console.SetCursorPosition(10 + employee.SecondName.Length - 1, 0);
                            Console.Write(" ");
                            employee.SecondName = employee.SecondName.Remove(employee.SecondName.Length - 1);
                            Console.SetCursorPosition(10 + employee.SecondName.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 5)
                {
                    employee.Name = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 5);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            employee.Name += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && employee.Name.Length != 0)
                        {
                            Console.SetCursorPosition(10 + employee.Name.Length - 1, 0);
                            Console.Write(" ");
                            employee.Name = employee.Name.Remove(employee.Name.Length - 1);
                            Console.SetCursorPosition(10 + employee.Name.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);


                }
                else if (choose == 6)
                {
                    employee.Surname = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 6);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            employee.Surname += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && employee.Surname.Length != 0)
                        {
                            Console.SetCursorPosition(10 + employee.Surname.Length - 1, 0);
                            Console.Write(" ");
                            employee.Surname = employee.Surname.Remove(employee.Surname.Length - 1);
                            Console.SetCursorPosition(10 + employee.Surname.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);
                }
                else if (choose == 7)
                {
                    employee.BirthDate = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 7);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            employee.BirthDate += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && employee.BirthDate.Length != 0)
                        {
                            Console.SetCursorPosition(10 + employee.BirthDate.Length - 1, 0);
                            Console.Write(" ");
                            employee.BirthDate = employee.BirthDate.Remove(employee.Surname.Length - 1);
                            Console.SetCursorPosition(10 + employee.BirthDate.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);
                }
                else if (choose == 8)
                {
                    employee.Passport = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(10, 8);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            employee.Passport += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && employee.Passport.Length != 0)
                        {
                            Console.SetCursorPosition(10 + employee.Passport.Length - 1, 0);
                            Console.Write(" ");
                            employee.Passport = employee.Passport.Remove(employee.Surname.Length - 1);
                            Console.SetCursorPosition(10 + employee.Passport.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);
                }

                else if (choose == 9)
                {
                    employee.Salary = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(8, 9);

                    employee.Salary += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 10)
                {
                    employee.UserId = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(8, 10);

                    employee.UserId += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 11)
                {
                    employee.Role = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(8, 11);

                    employee.Role += Convert.ToInt32(Console.ReadLine());
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

        public static List<Employee> readEmployees()
        {
            string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "employees.json"));
            List<Employee> result = JsonConvert.DeserializeObject<List<Employee>>(text);
            return result;
        }

        public static void newEmployeee(Employee newEmployee)
        {
            List<Employee> result = readEmployees();
            result.Add(newEmployee);
            string json = JsonConvert.SerializeObject(result);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "employees.json"), json);
        }
    }
}



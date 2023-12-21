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
    internal class StorageManager : ICrud
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
                    Console.WriteLine("ID, Имя, Цена за 1 шт., кол-во на складе                            |   F1 - Добавить запись. F2 - Найти запись.");


                    List<Product> Product = readProducts();
                    for (int i = 0; i < Product.Count; i++)
                    {
                        Console.WriteLine("   " + Product[i].Id + ", " + Product[i].Name + ", " + Product[i].priceForEach + ", " + Product[i].countInStorage);
                    }

                    int choose = Menu.Show(3, Product.Count + 2, 3);

                    if (choose <= Product.Count + 2)
                    {
                        edit(Product[choose - 3]);
                    }
                    else if (choose == 1000)
                    {
                        Console.Clear();
                        Login.loginn();
                    }
                }
            }
        }

        public static void edit(Product product)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("         Добро пожаловать, " + Login.login + "!" + "                 Роль: " + Login.userRole);
                Console.WriteLine("--------------------------------------------------------------------|--------------------------------------------------");
                Console.WriteLine("Редактирование пользователя                                         |   ESC - Выйти в меню. DEL - Удалить запись.");

                Console.WriteLine("   ID:" + product.Id);
                Console.WriteLine("   Название:" + product.Name);
                Console.WriteLine("   Цена за штуку:" + product.priceForEach);
                Console.WriteLine("   Колличество на складе:" + product.countInStorage);

                int choose = Menu.Show(3, 6, 3);

                if (choose == 3)
                {
                    product.Id = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(6, 3);

                    product.Id += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 4)
                {
                    product.Name = "";

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(9, 4);

                    do
                    {
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            product.Name += key.Key.ToString();
                        else if (key.Key == ConsoleKey.Backspace && product.Name.Length != 0)
                        {
                            Console.SetCursorPosition(10 + product.Name.Length - 1, 0);
                            Console.Write(" ");
                            product.Name = product.Name.Remove(product.Name.Length - 1);
                            Console.SetCursorPosition(10 + product.Name.Length, 0);
                        }
                    } while (key.Key != ConsoleKey.Escape);

                }
                else if (choose == 5)
                {
                    product.priceForEach = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(8, 5);

                    product.priceForEach += Convert.ToInt32(Console.ReadLine());
                }
                else if (choose == 6)
                {
                    product.countInStorage = 0;

                    ConsoleKeyInfo key = new ConsoleKeyInfo();
                    Console.SetCursorPosition(8, 6);

                    product.countInStorage += Convert.ToInt32(Console.ReadLine());
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

        public static List<Product> readProducts()
        {
            string text = File.ReadAllText("C:\\Users\\College\\source\\repos2\\Peterochka10\\products.json");
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(text);
            return result;
        }

        public static void newProduct(Product newProduct)
        {
            List<Product> result = readProducts();
            result.Add(newProduct);
            string json = JsonConvert.SerializeObject(result);
            File.WriteAllText("C:\\Users\\College\\source\\repos2\\Peterochka10\\products.json", json);
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

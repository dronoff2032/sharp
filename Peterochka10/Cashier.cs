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
    internal class Cashier : ICrud
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

                int choose = Menu.Show(3, 3, 3);

                if (choose == 1000)
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
            string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "products.json"));
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(text);
            return result;
        }

        public static void newProduct(Product newProduct)
        {
            List<Product> result = readProducts();
            result.Add(newProduct);
            string json = JsonConvert.SerializeObject(result);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "products.json"), json);
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

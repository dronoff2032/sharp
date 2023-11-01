using System.Data.Common;
using Tortiki;

Tort tortik = new Tort();
int tortikPrice = 0;

while (true)
{
    Console.Clear();

    Console.WriteLine("Давайте соберем ваш торт");
    Console.WriteLine("------------------------");
    Console.WriteLine("  Форма");
    Console.WriteLine("  Размер");
    Console.WriteLine("  Вкус");
    Console.WriteLine("  Количество коржей");
    Console.WriteLine("  Глазурь");
    Console.WriteLine("  Декор");
    Console.WriteLine("  Конец заказа");
    Console.WriteLine();
    Console.WriteLine("Ваш торт: Форма - " + tortik.form + ", размер - " + tortik.size + ", вкус - " + tortik.taste + ", количество коржей - " + tortik.korz + ", глазурь - " + tortik.glaze + ", декор - " + tortik.dekor);
    Console.WriteLine("Итоговая цена: " + tortikPrice);

    int menu1 = Menu.menu(8);

    if (menu1 == 2)
    {
        Console.Clear();

        Console.WriteLine("Выберите желаемую форму: ");
        Console.WriteLine("------------------------");
        Console.WriteLine("  Круг - 200р.");
        Console.WriteLine("  Прямоугольник - 300р.");
        Console.WriteLine("  Квадрат - 400р.");

        int menu2 = Menu.menu(4);

        if (tortik.form == "круг")
            tortikPrice = tortikPrice - 200;
        else if (tortik.form == "прямоугольник")
            tortikPrice = tortikPrice - 300;
        else if (tortik.form == "квадрат")
            tortikPrice = tortikPrice - 400;

        if (menu2 == 2)
        {
            tortik.form = "круг";
            tortikPrice = tortikPrice + 200;
        }
        else if (menu2 == 3)
        {
            tortik.form = "прямоугольник";
            tortikPrice = tortikPrice + 300;
        }
        else if (menu2 == 4)
        {
            tortik.form = "квадрат";
            tortikPrice = tortikPrice + 400;
        }
    }
    else if (menu1 == 3)
    {
        Console.Clear();

        Console.WriteLine("Выберите размер: ");
        Console.WriteLine("------------------------");
        Console.WriteLine("  Маленький - 400р.");
        Console.WriteLine("  Средний - 600р.");
        Console.WriteLine("  Большой - 800р.");
        Console.WriteLine("  Огромный - 1000р.");


        int menu3 = Menu.menu(5);

        if (tortik.size == "Маленький")
            tortikPrice = tortikPrice - 400;
        else if (tortik.size == "Средний")
            tortikPrice = tortikPrice - 600;
        else if (tortik.size == "Большой")
            tortikPrice = tortikPrice - 800;
        else if (tortik.size == "Огромный")
            tortikPrice = tortikPrice - 1000;

        if (menu3 == 2)
        {
            tortik.size = "Маленький";
            tortikPrice = tortikPrice + 400;
        }
        else if (menu3 == 3)
        {
            tortik.size = "Средний";
            tortikPrice = tortikPrice + 600;
        }
        else if (menu3 == 4)
        {
            tortik.size = "Большой";
            tortikPrice = tortikPrice + 800;
        }
        else if (menu3 == 5)
        {
            tortik.size = "Огромный";
            tortikPrice = tortikPrice + 1000;
        }
    }
    else if (menu1 == 4)
    {
        Console.Clear();

        Console.WriteLine("Выберите желаемый вкус: ");
        Console.WriteLine("------------------------");
        Console.WriteLine("  Малина - 1000р.");
        Console.WriteLine("  Клубника - 1000р.");
        Console.WriteLine("  Шоколад - 1000р.");
        Console.WriteLine("  Банан - 1000р.");


        int menu4 = Menu.menu(5);

        if (tortik.taste == null)
            tortikPrice = tortikPrice + 1000;


        if (menu4 == 2)
            tortik.taste = "Малина";
        else if (menu4 == 3)
            tortik.taste = "Клубника";
        else if (menu4 == 4)
            tortik.taste = "Шоколад";
        else if (menu4 == 5)
            tortik.taste = "Банан";
    }
    else if (menu1 == 5)
    {
        Console.Clear();

        Console.WriteLine("Введите колличество коржей (один корж - 500 рублей): ");
        Console.WriteLine("------------------------");

        tortikPrice = tortikPrice - 500 * tortik.korz;

        tortik.korz = Convert.ToInt32(Console.ReadLine());

        tortikPrice = tortikPrice + 500 * tortik.korz;

    }
    else if (menu1 == 6)
    {
        Console.Clear();

        Console.WriteLine("Выберите глазурь: ");
        Console.WriteLine("------------------------");
        Console.WriteLine("  Черная - 200р.");
        Console.WriteLine("  Шоколадная - 300р.");
        Console.WriteLine("  Молочная - 400р.");
        Console.WriteLine("  Белая - 500р.");
        Console.WriteLine("  Сахарная - 600р.");



        int menu5 = Menu.menu(6);

        if (tortik.glaze == "Черная")
            tortikPrice = tortikPrice - 200;
        else if (tortik.glaze == "Шоколадная")
            tortikPrice = tortikPrice - 300;
        else if (tortik.glaze == "Молочная")
            tortikPrice = tortikPrice - 400;
        else if (tortik.glaze == "Белая")
            tortikPrice = tortikPrice - 500;
        else if (tortik.glaze == "Сахарная")
            tortikPrice = tortikPrice - 600;

        if (menu5 == 2)
        {
            tortik.glaze = "Черная";
            tortikPrice = tortikPrice + 200;
        }
        else if (menu5 == 3)
        {
            tortik.glaze = "Шоколадная";
            tortikPrice = tortikPrice + 300;
        }
        else if (menu5 == 4)
        {
            tortik.glaze = "Молочная";
            tortikPrice = tortikPrice + 400;
        }
        else if (menu5 == 5)
        {
            tortik.glaze = "Белая";
            tortikPrice = tortikPrice + 500;
        }
        else if (menu5 == 5)
        {
            tortik.glaze = "Сахарная";
            tortikPrice = tortikPrice + 600;
        }
    }
    else if (menu1 == 7)
    {
        Console.Clear();

        Console.WriteLine("Выберите декор: ");
        Console.WriteLine("------------------------");
        Console.WriteLine("  Мастика - 500р.");
        Console.WriteLine("  Крем - 700р.");
        Console.WriteLine("  Фрукты и ягоды - 1100р.");

        int menu6 = Menu.menu(4);

        if (tortik.dekor == "Мастика")
            tortikPrice = tortikPrice - 500;
        else if (tortik.dekor == "прямоугольник")
            tortikPrice = tortikPrice - 700;
        else if (tortik.dekor == "Фрукты и ягоды")
            tortikPrice = tortikPrice - 1100;

        if (menu6 == 2)
        {
            tortik.dekor = "Мастика";
            tortikPrice = tortikPrice + 500;
        }
        else if (menu6 == 3)
        {
            tortik.dekor = "Крем";
            tortikPrice = tortikPrice + 700;
        }
        else if (menu6 == 4)
        {
            tortik.dekor = "Фрукты и ягоды";
            tortikPrice = tortikPrice + 1100;
        }
    } else if (menu1 == 8)
    {
        File.AppendAllText("C:\\Users\\xelond\\Documents\\order_history.txt", "Дата: " + DateTime.Now + "\n   Заказа: Форма - " + tortik.form + ", размер - " + tortik.size + ", вкус - " + tortik.taste + ", количество коржей - " + tortik.korz + ", глазурь - " + tortik.glaze + ", декор - " + tortik.dekor + "\n   Цена " + tortikPrice);
        tortik = new Tort();
    }
}
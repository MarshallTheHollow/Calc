using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Калькуратор_отжиманий
{
    [Serializable]
    class Program
    {
        static int p = 0;
        static int otg = 0;
        static string number;
        static BinaryFormatter binFormat = new BinaryFormatter();
        static void Main(string[] args)
        {
            using (FileStream fStream = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                otg = (int)binFormat.Deserialize(fStream);
            }
            Console.WriteLine("Добро пожаловать!");
        Start:          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Ваши отжимания: {otg}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Существующие команды:\nДобавить - добавляет ваши отжимания\nОчистить - очищает ваши отжимания\nEsc - выход");
            ConsoleKey Keyy = Console.ReadKey().Key;
            if (Keyy == ConsoleKey.Escape)
            {
                Goodbye();
            }
            else
            {
                string selection = Console.ReadLine();               
                Sich(selection);
                goto Start;               
            }
        }
        static int OtgCheck()
        {
            otg = p * 2;
            return otg;
        }
        static void Goodbye()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(25);
            Console.WriteLine("F");
            Console.WriteLine("Дос видания! F.\n");
            Thread.Sleep(300);
            Console.WriteLine(".");
            Thread.Sleep(300);
            Console.WriteLine(".");
            Thread.Sleep(300);
            Console.WriteLine(".");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(300);
            return;
        }
        static void Sich(string selection)
        {
            switch (selection)
            {
                case "обавить":
                    Console.WriteLine("Введите ваш топ");
                    try
                    {
                        number = Console.ReadLine();
                        p += Convert.ToInt32(number);
                        OtgCheck();
                        using (Stream fStream = new FileStream("user.dat",
                        FileMode.Create))
                        {
                            binFormat.Serialize(fStream, otg);
                        }
                        if (Convert.ToInt32(number) == 1)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("ХРШ ХРШ. 777\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (Convert.ToInt32(number) == 8)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("ОТРАЖАЮ ПОРЧУ.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    catch (SystemException)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ВВЕДЕН НЕВЕРНЫЙ ФОРМАТ.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case "обавить";
                    }
                    return;
                case "чистить":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Отжимания очищены\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    p = 0;
                    OtgCheck();
                    using (Stream fStream = new FileStream("user.dat",
                        FileMode.Create))
                    {
                        binFormat.Serialize(fStream, otg);
                    }
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы нажали неизвестную команду\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
            }
        }
    }
}

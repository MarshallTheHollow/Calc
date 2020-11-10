using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Калькуратор_отжиманий
{
    [Serializable]
    class Program
    {
        static int p;
        static int otg;
        static string number;
        static int LCount;
        static BinaryFormatter binFormat = new BinaryFormatter();
        static void Main(string[] args)
        {
            DataCheck();
            Console.WriteLine("Добро пожаловать!");
        Start:          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Ваши отжимания: {otg}\n");           
            Console.WriteLine($"Лавров съел уже {LCount} барбарисок\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Существующие команды:\nДобавить - добавляет ваши отжимания\nОчистить - очищает ваши отжимания\nЛавров - Владислав Васильевич съедает еще одну барбариску\nВыход - выход");
            string selection = Console.ReadLine();               
            Sich(selection);
            goto Start;               
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
                case "Добавить":
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
                        goto case "Добавить";
                    }
                    return;
                case "Очистить":
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
                case "Лавров":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Принято!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    LCount ++;
                    OtgCheck();
                    using (Stream fStream2 = new FileStream("user2.dat",
                        FileMode.Create))
                    {
                        binFormat.Serialize(fStream2, LCount);
                    }
                    return;
                case "Выход":
                    Console.Clear();
                    Goodbye();
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы нажали неизвестную команду\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
            }
        }
        static void DataCheck()
        {
            using (FileStream fStream = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                otg = (int)binFormat.Deserialize(fStream);
            }
            using (FileStream fStream2 = new FileStream("user2.dat", FileMode.OpenOrCreate))
            {
                LCount = (int)binFormat.Deserialize(fStream2);
            }
        }
    }
}

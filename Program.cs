using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Калькуратор_отжиманий
{
    [Serializable]
    class Program
    {
        static int otg = SerializePushUps.GetPushUps();
        static int number;
        static BinaryFormatter binFormat = new BinaryFormatter();
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Добро пожаловать!");
            Start:          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Ваши отжимания: {otg}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available commands:\nadd - добавляет ваши отжимания\nclear - очищает ваши отжимания\nEsc - выход");
           /// ConsoleKey Keyy = Console.ReadKey().Key;
            string selection = Console.ReadLine();               
            Swich(selection.Trim());
            goto Start;
        }
        
        static void Goodbye()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(25);
            Console.WriteLine("F");
            Console.WriteLine("Good Buy! F.\n");
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
        static void Swich(string selection)
        {
            switch (selection)
            {
                case "add":
                    Console.WriteLine("Введите ваш топ");
                    try
                    {
                        number = Convert.ToInt32(Console.ReadLine());
                        otg += Convert.ToInt32(SetOtg(number));
                        SerializePushUps.UpdatePushUps(otg);
                        if (number == 1)
                        {
                            updateConsole("ХРШ ХРШ. 777\n", ConsoleColor.Green);
                        }
                        if (number == 8)
                        {
                            updateConsole("ОТРАЖАЮ ПОРЧУ.\n", ConsoleColor.Yellow);
                        }
                    }
                    catch (SystemException)
                    {
                        updateConsole("ВВЕДЕН НЕВЕРНЫЙ ФОРМАТ.\n", ConsoleColor.Red);
                        goto case "add";
                    }
                    return;
                case "clear":
                    updateConsole("Отжимания очищены\n", ConsoleColor.Green);
                    otg = SetOtg(0);
                    return;
                default:
                    updateConsole("Ty eblan sho-le?\n", ConsoleColor.White);
                    return;
            }
        }
        static int SetOtg(int count)
        {
            return count * 3; //го больше делать, оло
        }
        static void updateConsole(string content, ConsoleColor CurrentConsoleColor)
        {
            Console.Clear();
            Console.ForegroundColor = CurrentConsoleColor;
            Console.WriteLine($"{content}.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

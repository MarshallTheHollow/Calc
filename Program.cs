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
        static int LCount = SerializePushUps.GetPushUps();//хуйня не работает, Диабублик почини (Саня)
        static int number;
        static BinaryFormatter binFormat = new BinaryFormatter();
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome!");
            Start:          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your otgimania: {otg}");
            Console.WriteLine($"Lavrov eats at least {LCount} barbarises");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available commands:\nadd - add your otgimania\nclear - clear your otgimania\nLavrov - Add one more barbaris\noff - offaet nahoy");
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
                    Console.WriteLine("Add your top");
                    try
                    {
                        NumberCheck();
                        otg += Convert.ToInt32(SetOtg(number));
                        SerializePushUps.UpdatePushUps(otg);
                        if (number == 1)
                        {
                            updateConsole("HRSH HRSH. 777", ConsoleColor.Green);
                        }
                        if (number == 8)
                        {
                            updateConsole("REFFLECT THE CORRUPTION.", ConsoleColor.Yellow);
                        }
                    }
                    catch (SystemException)
                    {
                        updateConsole("System Exeption, so see.", ConsoleColor.Red);
                        goto case "add";
                    }
                    return;
                case "clear":
                    updateConsole("Отжимания очищены", ConsoleColor.Green);
                    otg = SetOtg(0);
                    return;
                case "Lavrov":
                    updateConsole("Anderstendable", ConsoleColor.Green);
                    LCount++;
                    SerializePushUps.UpdatePushUps(LCount);
                    return;
                case "off":
                    Goodbye();
                    return;
                default:
                    updateConsole("Error", ConsoleColor.White);
                    return;
            }
        }
        static int NumberCheck()
        {
            check:
            number = Convert.ToInt32(Console.ReadLine());
            if (number >=1 && number <= 8)
            {
                return number;
            }
            else
            {
                updateConsole("this top does not exist, Dyadya", ConsoleColor.Red);
                goto check;
            }
        }
        static int SetOtg(int count)
        {
            return count * 3; //го больше делать, оло|| ты моей смерти хочешб
        }
        static void updateConsole(string content, ConsoleColor CurrentConsoleColor)
        {
            Console.Clear();
            Console.ForegroundColor = CurrentConsoleColor;
            Console.WriteLine($"{content}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

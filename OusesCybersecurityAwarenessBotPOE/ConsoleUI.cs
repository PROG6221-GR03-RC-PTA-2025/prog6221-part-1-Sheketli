using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    internal class ConsoleUI
    {
        public static void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }

            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void DisplayExitMessage()
        {
            ConsoleUI.PrintMessage("Thank you for using the Ouses Cybersecurity Awareness Bot!" +
                              "\nStay safe online and have a great day!", ConsoleColor.Green);
            Console.ResetColor();
        }
    }
}

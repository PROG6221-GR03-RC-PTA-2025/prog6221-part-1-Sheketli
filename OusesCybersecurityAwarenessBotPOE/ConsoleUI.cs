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
        // Method to display the main menu
        public static void PrintMessage(string message, ConsoleColor color)
        {
            // Set the console color
            Console.ForegroundColor = color;

            // Print the message character by character with a delay
            foreach (char c in message)
            {
                Console.Write(c);// Print the character
                Thread.Sleep(20);// Delay for 20 milliseconds
            }
            // Print a new line after the message
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        // Method to display the main menu
        public static void DisplayExitMessage()
        {
            Console.WriteLine();
            // Print a message to the user
            ConsoleUI.PrintMessage("Thank you for using the Ouses Cybersecurity Awareness Bot!" +
                                   "\nStay safe online and have a great day!", ConsoleColor.Green);
            Console.ResetColor();
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

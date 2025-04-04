using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Enable special characters for better console display

            Console.Title = "Ouses Cybersecurity Awareness Bot"; // Set console window title

            //Console.SetWindowSize(132, 41); // Set console window size

            // Display a message before the audio has played
            ConsoleUI.PrintMessage("\nHello, Welcome to Ouses Cybersecurity Awareness Bot!" +
                                 "\nI'm here to help you stay safe online.", ConsoleColor.Green);

            // Display ASCII Art logo
            AsciiArt.DisplayLogo();

            // Play voice greeting using a pre-recorded sound file
            AudioPlayer.PlayGreeting();

            // Initialize and start the chatbot
            ChatBot chatbot = new ChatBot();
            chatbot.Start();
        }
    }
}

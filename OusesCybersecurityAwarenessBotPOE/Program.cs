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

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();

            // Display a message before the audio has played
            ConsoleUI.PrintMessage("\nHello, Welcome to Ouses Cybersecurity Awareness Bot!" +
                                 "\nI'm here to help you stay safe online.", ConsoleColor.Green);

            // Play voice greeting using a pre-recorded sound file
            AudioPlayer.PlayGreeting();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();

            // Display ASCII Art logo
            AsciiArt.DisplayLogo();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();


            // Initialize and start the chatbot
            ChatBot chatbot = new ChatBot();
            chatbot.Start();

            ChatBot memory = new ChatBot();
            ChatBot bot = new ChatBot(memory);

            string interest = ConsoleUI.GetUserInput("\nWhat cybersecurity topic are you interested in? (e.g., privacy, phishing): ");
            bot.AskCyberTopic(interest);

            Console.WriteLine("\nLater in the conversation...");
            bot.GivePersonalizedTip();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
        }
    }
}

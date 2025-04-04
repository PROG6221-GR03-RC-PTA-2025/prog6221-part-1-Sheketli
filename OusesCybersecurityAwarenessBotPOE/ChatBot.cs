using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    internal class ChatBot
    {
        string name = null;
        string userInput = null;

        // Method to start the chatbot interaction
        public void Start()
        {
            Console.WriteLine();

            // Prompt user for their name
            ConsoleUI.PrintMessage("Please enter your name here>>", ConsoleColor.Green);
            name = Console.ReadLine()?.Trim();

            // Validate user input for name
            while (string.IsNullOrEmpty(name))
            {
                ConsoleUI.PrintMessage("What you entered is invalid!" +
                                       "\nYour name cannot be empty.", ConsoleColor.Red);
                ConsoleUI.PrintMessage("Please enter your name here>>", ConsoleColor.Green);
                name = Console.ReadLine()?.Trim();
            }

            // Greet user and introduce available topics or exit command
            ConsoleUI.PrintMessage($"\nHello, {name}! I'm here to help you stay safe online.", ConsoleColor.Green);
            ConsoleUI.PrintMessage("Ask me about:" +
                                   "\n- Password Safety" +
                                   "\n- Phishing" +
                                   "\n- Safe Browsing" +
                                   "\n- virus" +
                                   "\n- encryption" +
                                   "\n- firewall" +
                                   "\n- malware" +
                                   "\n...or anything about cybersecurity awareness.", ConsoleColor.Yellow);
            ConsoleUI.PrintMessage("Type 'exit' or 'quit' to end the conversation.", ConsoleColor.DarkRed);

            if (userInput == "exit" || userInput == "quit")
            {
                ConsoleUI.DisplayExitMessage();
                return;
            }

            // Start chatbot conversation loop
            ChatLoop();
        }

        // Main chatbot interaction loop
        private void ChatLoop()
        {
            while (true)
            {
                ConsoleUI.PrintMessage("You: ", ConsoleColor.Blue);

                // Get user input
                string input = Console.ReadLine()?.Trim().ToLower(); // Normalize input

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleUI.PrintMessage("Bot: Please enter a valid question.", ConsoleColor.Red);
                    continue;
                }

                // Check if the input is an exit command
                if (input == "exit" || input == "quit")
                {
                    ConsoleUI.DisplayExitMessage();
                    return;
                }

                // Call the RespondToQuestion method to handle the input
                RespondToQuestion(input);
            }
        }

        private static void RespondToQuestion(string question)
        {
            Console.WriteLine();
            // Basic responses based on keywords
            if (question.Contains("virus"))
            {
                ConsoleUI.PrintMessage("Bot: Viruses are malicious software that can replicate themselves and spread to other computers.", ConsoleColor.Cyan);
            }
            else if (question.Contains("password safety"))
            {
                ConsoleUI.PrintMessage("Bot: Password safety is crucial. Use strong, unique passwords and enable two-factor authentication.", ConsoleColor.Cyan);
            }
            else if (question.Contains("safe browsing"))
            {
                ConsoleUI.PrintMessage("Bot: Safe browsing involves avoiding suspicious links and ensuring websites are secure.", ConsoleColor.Cyan);
            }
            else if (question.Contains("encryption"))
            {
                ConsoleUI.PrintMessage("Bot: Encryption is the process of converting information into a code to prevent unauthorized access.", ConsoleColor.Cyan);
            }
            else if (question.Contains("phishing"))
            {
                ConsoleUI.PrintMessage("Bot: Phishing is a method used by cybercriminals to trick individuals into providing sensitive information.", ConsoleColor.Cyan);
            }
            else if (question.Contains("firewall"))
            {
                ConsoleUI.PrintMessage("Bot: A firewall is a network security system that monitors and controls incoming and outgoing network traffic.", ConsoleColor.Cyan);
            }
            else if (question.Contains("malware"))
            {
                ConsoleUI.PrintMessage("Bot: Malware is software designed to disrupt, damage, or gain unauthorized access to computer systems.", ConsoleColor.Cyan);
            }
            else
            {
                ConsoleUI.PrintMessage("Bot: I'm not sure about that. Can you ask something else related to cybersecurity?", ConsoleColor.Red);
            }
        }
    }
}

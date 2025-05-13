using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    // delegate to handle user input and provide a response
    public delegate string ResponseDelegate(string input);

    internal class ChatBot
    {
        // Properties to store user information
        string name = null;
        string userInput = null;

        // Dictionary to store keyword responses
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();
        private Dictionary<string, string> sentimentResponses = new Dictionary<string, string>();
        private UserMemory memory = new UserMemory();
        private Random rand = new Random();

        // Constructor to initialize the chatbot
        public ChatBot()
        {
            InitializeKeywordResponses();
            InitializeSentimentResponses();
        }

        // Method to initialize keyword responses
        private void InitializeKeywordResponses()
        {
            keywordResponses["password"] = new List<string>
            {
                "Use a mix of letters, numbers, and symbols in your passwords.",
                "Never reuse the same password across multiple sites.",
                "Avoid using personal details in your passwords."
            };
            keywordResponses["scam"] = new List<string>
            {
                "If something sounds too good to be true, it probably is.",
                "Always verify links and email addresses before clicking.",
                "Watch out for urgent messages asking for personal info."
            };
            keywordResponses["privacy"] = new List<string>
            {
                "Adjust your social media privacy settings.",
                "Only share personal info on secure sites.",
                "Use two-factor authentication."
            };
            keywordResponses["phishing"] = new List<string>
            {
                "Be cautious of emails asking for login details.",
                "Do not click suspicious links in emails.",
                "Legitimate companies never ask for passwords via email."
            };
        }

        // Method to initialize sentiment responses
        private void InitializeSentimentResponses()
        {
            sentimentResponses["happy"] = "I'm glad to hear that!";
            sentimentResponses["sad"] = "I'm sorry to hear that. If you need someone to talk to, I'm here for you.";
            sentimentResponses["angry"] = "It's okay to feel angry sometimes. Let's talk about it.";
            sentimentResponses["confused"] = "It's normal to feel confused. Can I help clarify something for you?";
            sentimentResponses["worried"] = "It's okay to feel worried. Cybersecurity can be tricky, but you're not alone!";
            sentimentResponses["curious"] = "Curiosity is great! Let's explore online safety together.";
            sentimentResponses["frustrated"] = "I get that this can be frustrating. I'm here to help make it easier.";
            sentimentResponses["excited"] = "That's awesome! Let's channel that excitement into learning about online safety.";
            sentimentResponses["bored"] = "Let's turn that boredom into something productive! How about learning a new cybersecurity tip?";
        }

        // Method to handle user input and provide a response
        public string ProcessInput(string input)
        {
            input = input.ToLower();

            ResponseDelegate[] processors =
            {
            DetectSentiment,
            UpdateMemory,
            CheckForKeyword
            };

            foreach (var process in processors)
            {
                string result = process(input);
                if (result != null)
                    return result;
            }
            return "I'm not sure I understand. Can you try rephrasing?";
        }

        // Method to detect sentiment in user input
        private string DetectSentiment(string input)
        {
            foreach (var pair in sentimentResponses)
            {
                if (input.Contains(pair.Key))
                    return pair.Value;
            }
            return null;
        }

        // Method to update user memory based on input
        private string UpdateMemory(string input)
        {
            if (input.Contains("my name is"))
            {
                memory.Name = input.Substring(input.LastIndexOf("is") + 3).Trim();
                return $"Nice to meet you, {memory.Name}!";
            }

            if (input.Contains("i'm interested in"))
            {
                memory.FavoriteTopic = input.Substring(input.LastIndexOf("in") + 3).Trim();
                return $"Great! I'll remember that you're interested in {memory.FavoriteTopic}.";
            }
            if (input.Contains("my favorite topic is"))
            {
                memory.FavoriteTopic = input.Substring(input.LastIndexOf("is") + 3).Trim();
                return $"Got it! Your favorite topic is {memory.FavoriteTopic}.";
            }

            return null;
        }

        // Method to check for keywords in user input and provide a response
        private string CheckForKeyword(string input)
        {
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    string prefix = memory.FavoriteTopic == keyword
                        ? $"Since you're interested in {keyword}, here's a tip: "
                        : "";

                    var responses = keywordResponses[keyword];
                    return prefix + responses[rand.Next(responses.Count)];
                }
            }

            return null;
        }

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

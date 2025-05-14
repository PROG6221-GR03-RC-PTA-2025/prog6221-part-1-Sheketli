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
        // Dictionary to store keyword responses
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();
        private Dictionary<string, string> sentimentResponses = new Dictionary<string, string>();
        private UserMemory memory = new UserMemory();
        private Random rand = new Random();

        // Properties to store user information
        string name = null;

        public ChatBot(UserMemory memory)
        {
            this.memory = memory;
        }

        // Method to greet the user and remember their name
        public void GreetUser(string name)
        {
            memory.Remember("name", name);
            Console.WriteLine($"Nice to meet you, {name}! I'm here to help you with cybersecurity tips.");
        }

        // Method to ask the user about their interest in a specific cybersecurity topic
        public void AskCyberTopic(string input)
        {
            if (input.IndexOf("privacy", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                memory.Remember("interest", "privacy");
                Console.WriteLine("Great! I'll remember that you're interested in privacy. It's a crucial part of staying safe online.");
            }
            else if (input.IndexOf("phishing", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                memory.Remember("interest", "phishing");
                Console.WriteLine("Got it! You're interested in phishing. That’s an important topic to understand.");
            }
            else
            {
                Console.WriteLine("Thanks for sharing! I’ll keep that in mind.");
            }
        }

        public void GivePersonalizedTip()
        {
            if (memory.HasMemory("interest"))
            {
                string interest = memory.Recall("interest");
                Console.WriteLine($"As someone interested in {interest}, you might want to explore more resources or tools to protect yourself.");
            }
            else
            {
                Console.WriteLine("Let me know what cybersecurity topic you're interested in, so I can give you better tips!");
            }
        }

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
                "Use a mix of letters, numbers, and symbols in your passwords.\n Never reuse the same password across multiple sites.\n Avoid using personal details in your passwords.",
            };

            keywordResponses["scam"] = new List<string>
            {
                "If something sounds too good to be true, it probably is.\n Always verify links and email addresses before clicking.\n Watch out for urgent messages asking for personal info.",
            };
            keywordResponses["privacy"] = new List<string>
            {
                "Adjust your social media privacy settings.\n Only share personal info on secure sites.\n Use two-factor authentication.",
            };

            keywordResponses["encryption"] = new List<string>
            {
                "Encryption protects your data by converting it into a code.\n Use encryption for sensitive files and communications.\n End-to-end encryption ensures only you and the recipient can read the messages.",
            };

            keywordResponses["malware"] = new List<string>
            {
                "Malware can steal your data or damage your system.\n Keep your antivirus software updated.\n Avoid downloading files from untrusted sources.",
            };

            keywordResponses["safe browsing"] = new List<string>
            {
                "Always check for HTTPS in the URL before entering sensitive information.\n Avoid clicking on pop-up ads or suspicious links.\n Use a reputable browser with built-in security features.",
            };

            keywordResponses["virus"] = new List<string>
            {
                "A virus is a type of malware that can replicate itself.\n Keep your operating system and software updated to prevent viruses.\n Run regular scans with your antivirus software.",
            };

            keywordResponses["firewall"] = new List<string>
            {
                "A firewall acts as a barrier between your computer and the internet.\n Keep your firewall enabled to protect against unauthorized access.\n Regularly update your firewall settings.",
            };

            keywordResponses["phishing"] = new List<string>
            {
                "Be cautious of emails asking for login details.\n Do not click suspicious links in emails.\n Legitimate companies never ask for passwords via email.",
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

            foreach (var pair in sentimentResponses)
            {
                if (input.Contains(pair.Key))
                    return pair.Value;
            }
            return "I'm not sure I understand. Can you try rephrasing?";
        }

        // Method to detect sentiment in user input
        private string DetectSentiment(string input)
        {
            foreach (var pair in sentimentResponses)
            {
                if (input.Contains(pair.Key)) return pair.Value;
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

            memory.Name = name;

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

            // Start chatbot conversation loop
            ChatLoop();
        }

        // Main chatbot interaction loop
        private void ChatLoop()
        {
            while (true)
            {
                // Get user input
                ConsoleUI.PrintMessage("You: ", ConsoleColor.Blue);
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

                string response = DetectSentiment(input) ?? UpdateMemory(input) ?? CheckForKeyword(input) ?? "I'm not sure I understand. Can you rephrase?";

                ConsoleUI.PrintMessage("Bot: " + response, ConsoleColor.Cyan);
            }
        }
    }
}

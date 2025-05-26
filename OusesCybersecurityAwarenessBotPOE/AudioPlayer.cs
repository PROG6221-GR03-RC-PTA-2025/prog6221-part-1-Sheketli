using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    internal class AudioPlayer
    {
        public static void PlayGreeting()
        {
            string audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), "HumeAI_2025May26_0429b5e2-51bd-4612-a364-885a1a7c9205146656_5971312b-bf16-4a01-a7f1-ac0da314d096.wav"); // Ensure full path resolution
            try
            {
                using (SoundPlayer player = new SoundPlayer(audioFilePath))
                {
                    player.Load(); // Load the audio file
                    player.PlaySync(); // Play audio synchronously
                }
                Thread.Sleep(1000); // Delay to allow the sound to finish
            }
            catch (Exception ex)
            {
                ConsoleUI.PrintMessage("Error playing audio: " + ex.Message, ConsoleColor.Red);
                Console.ResetColor();
            }
        }
    }
}

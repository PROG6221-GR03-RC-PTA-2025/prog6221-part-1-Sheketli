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
            string audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), "WelcomeToOuses.wav"); // Ensure full path resolution
            try
            {
                using (SoundPlayer player = new SoundPlayer(audioFilePath))
                {
                    player.Load(); // Load the audio file
                    player.PlaySync(); // Play audio synchronously
                }
                Thread.Sleep(3000); // Delay to allow the sound to finish
            }
            catch (Exception ex)
            {
                ConsoleUI.PrintMessage("Error playing audio: " + ex.Message, ConsoleColor.Red);
                Console.ResetColor();
            }
        }
    }
}

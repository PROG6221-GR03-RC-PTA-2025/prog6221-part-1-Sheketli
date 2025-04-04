using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    internal class AsciiArt
    {// Method to display the ASCII logo
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
|=================================================|
|    ██████╗ ██╗   ██╗███████╗███████╗███████╗    |
|   ██╔═══██╗██║   ██║██╔════╝██╔════╝██╔════╝    |
|   ██║   ██║██║   ██║███████╗█████╗  ███████╗    | 
|   ██║   ██║██║   ██║╚════██║██╔══╝  ╚════██║    |
|   ╚██████╔╝╚██████╔╝███████║███████╗███████║    |
|    ╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚══════╝    |
|   Optimized User Security & Encryption Solutions|
|   Cybersecurity Awareness Bot                   |   
|   Stay Safe Online!                             |
|=================================================|");

            // Reset console text color to default
            Console.ResetColor();
        }
    }
}

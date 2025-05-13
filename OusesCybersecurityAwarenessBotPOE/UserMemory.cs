using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    public delegate string ResponseDelegate(string input);

    internal class UserMemory
    {
        public string Name { get; set; }
        public string FavoriteTopic { get; set; }
    }
}

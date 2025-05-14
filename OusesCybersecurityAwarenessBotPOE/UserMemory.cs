using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OusesCybersecurityAwarenessBotPOE
{
    internal class UserMemory
    {
        private Dictionary<string, string> memory = new Dictionary<string, string>();

        public string Name { get; set; }
        public string FavoriteTopic { get; set; }

        public void Remember(string key, string value)
        {
            memory[key] = value;
        }

        public string Recall(string key)
        {
            return memory.ContainsKey(key) ? memory[key] : null;
        }

        public bool HasMemory(string key)
        {
            return memory.ContainsKey(key);
        }
    }
}

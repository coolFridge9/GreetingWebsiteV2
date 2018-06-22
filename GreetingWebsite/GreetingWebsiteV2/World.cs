using System.Collections.Generic;

namespace GreetingWebsiteV2
{
    public class World
    {
        private static readonly string undeletablePerson = "Jordan";
        public readonly List<string> Names = new List<string>{undeletablePerson};
            
        public void AddName(string name)
        {
            Names.Add(name);
        }

        public bool DeleteName(string data)
        {
            if (!Names.Contains(data) || data == undeletablePerson) return false;
            Names.Remove(data);
            return true;

        }
    }
}
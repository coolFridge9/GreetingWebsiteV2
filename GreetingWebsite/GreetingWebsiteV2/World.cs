using System.Collections.Generic;

namespace GreetingWebsiteV2
{
    public class World
    {
        public readonly List<string> Names = new List<string>{"Jordan"};
            
        public void AddName(string name)
        {
            Names.Add(name);
        }
    }
}
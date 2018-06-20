using System.Collections.Generic;
using System.Threading;

namespace GreetingWebsiteV2
{
    public class TextGenerator
    {
        public string GetTextGET(World world)
        {
            return "Hello "+OrganiseNames(world.Names);
        }

        public string GetTextPOST(string postedData)
        {
            return "You posted " + postedData;
        }
        
        private string OrganiseNames(List<string> worldNames)
        {
            var nameString = "";
            var count = 0;
            
            foreach (var name in worldNames)
            {
                count += 1;
                
                var grammarChar = count == worldNames.Count -1  ? " and " : ", ";
                if(count == worldNames.Count)
                    grammarChar = "";
                nameString += name+ grammarChar;
            }

            return nameString;
        }
    }
}
using System.Collections.Generic;
using System.Threading;

namespace GreetingWebsiteV2
{
    public class TextGenerator
    {
        public string GetTextGET(List<string> worldNames)
        {
            return "Hello "+OrganiseNames(worldNames);
        }

        public string GetTextPOST(string data)
        {
            return "Thanks " + data;
        }
        
        public string GetTextDELETE(string data)
        {
             return data + " deleted";
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

        public string GetTextDELETEFailed()
        {
            return "user doesn't exist";
        }

        public string GetTextPUTFailed()
        {
            return "user doesn't exist";
        }

        public string GetTextPUT()
        {
            throw new System.NotImplementedException();
        }
    }
}
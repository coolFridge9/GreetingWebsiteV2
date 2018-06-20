namespace GreetingWebsiteV2
{
    public class TextGenerator
    {
        public string GetTextGET()
        {
            return "Hello World";
        }

        public string GetTextPOST(string postedData)
        {
            return "You posted " + postedData;
        }
    }
}
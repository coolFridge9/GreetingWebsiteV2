using System;
using Xunit;

namespace GreetingWebsiteV2.Test
{
    public class TextGeneratorShould
    {
        [Fact]
        public void ReturnHelloWorldFromGet()
        {
            TextGenerator textGenerator = new TextGenerator();
            var text = textGenerator.GetTextGET();
            Assert.Equal("Hello World", text);

        }
        [Fact]
        public void ReturnPostedFromPost()
        {
            TextGenerator textGenerator = new TextGenerator();
            var postedData = "jordan";
            var text = textGenerator.GetTextPOST(postedData);
            Assert.Equal("You posted jordan", text);

        }
    }
}
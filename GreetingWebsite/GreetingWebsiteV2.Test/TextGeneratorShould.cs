using System;
using Xunit;

namespace GreetingWebsiteV2.Test
{
    public class TextGeneratorShould
    {
        [Fact]
        public void ReturnHelloWorld()
        {
            TextGenerator textGenerator = new TextGenerator();
            var text = textGenerator.GetText();
            Assert.Equal("Hello World", text);

        }
    }
}
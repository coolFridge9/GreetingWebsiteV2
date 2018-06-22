using System;
using Xunit;

namespace GreetingWebsiteV2.Test
{
    public class TextGeneratorShould
    {
        [Fact]
        public void ReturnHelloJordanFromGet()
        {
            var world = new World();
            var textGenerator = new TextGenerator();
            var text = textGenerator.GetTextGET(world.Names);
            Assert.Equal("Hello Jordan", text);
        }
        
        [Fact]
        public void ReturnHelloAndKarenFromGet()
        {
            var world = new World();
            world.AddName("Karen");
            var textGenerator = new TextGenerator();
            var text = textGenerator.GetTextGET(world.Names);
            Assert.Equal("Hello Jordan and Karen", text);
        }
        [Fact]
        public void ReturnHelloAndKarenErichFromGet()
        {
            var world = new World();
            world.AddName("Karen");
            world.AddName("Erich");
            var textGenerator = new TextGenerator();
            var text = textGenerator.GetTextGET(world.Names);
            Assert.Equal("Hello Jordan, Karen and Erich", text);
        }
        [Fact]
        public void ReturnHelloAndKarenErichRobFromGet()
        {
            var world = new World();
            world.AddName("Karen");
            world.AddName("Erich");
            world.AddName("Rob");
            var textGenerator = new TextGenerator();
            var text = textGenerator.GetTextGET(world.Names);
            Assert.Equal("Hello Jordan, Karen, Erich and Rob", text);
        }
        [Fact]
        public void ReturnPostedFromPost()
        {
            var textGenerator = new TextGenerator();
            var postedData = "jordan";
            var text = textGenerator.GetTextPOST(postedData);
            Assert.Equal("Thanks jordan", text);

        }
        [Fact]
        public void ReturndataFromDelete()
        {
            var textGenerator = new TextGenerator();
            var postedData = "james";
            var text = textGenerator.GetTextDELETE(postedData);
            Assert.Equal("james deleted", text);
        }
        
        [Fact]
        public void ReturndataFromDeleteWhenFailed()
        {
            var textGenerator = new TextGenerator();
            var data = "Jordan";
            var text = textGenerator.GetTextDELETE(data);
            Assert.Equal("Jordan deletion failed", text);

        }
    }
}
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace GreetingWebsiteV2.Test
{
    public class WorldShould
    {
        [Fact]
        public void AddPeopleToTheWorld()
        {
            const string name = "karen";
            var world = new World();
            world.AddName(name);
            var expected = new List<string> {"Jordan", "karen"};
            Assert.Equal(expected,world.Names);
        }
        [Fact]
        public void StartWithJordanOnly()
        {
            var world = new World();
            var expected = new List<string> {"Jordan"};
            Assert.Equal(expected,world.Names);
        }
    }
}
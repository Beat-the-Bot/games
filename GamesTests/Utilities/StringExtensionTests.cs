using Jarrus.Games.Utilities;
using System.Linq;
using Xunit;

namespace Jarrus.GamesTests.Utilities
{
    public class StringExtensionTests
    {
        [Fact]
        public void ItShouldGetAllInstancesOfSubstring()
        {
            var str = "ABCABCABC";
            var positions = str.AllIndexesOf("A");

            Assert.Equal(3, positions.Count());
            Assert.Equal(0, positions.ElementAt(0));
            Assert.Equal(3, positions.ElementAt(1));
            Assert.Equal(6, positions.ElementAt(2));
        }
    }
}

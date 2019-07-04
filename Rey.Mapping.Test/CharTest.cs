using Xunit;

namespace Rey.Mapping.Test {
    public class CharTest : TestBase {
        [Fact]
        public void Test() {
            Assert.Equal('a', this.Mapper.From('a').To<char>());
            Assert.Equal("a", this.Mapper.From('a').To<string>());
        }
    }
}

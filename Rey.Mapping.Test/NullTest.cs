using Rey.Mapping.Test.Models;
using Xunit;

namespace Rey.Mapping.Test {
    public class NullTest : TestBase {
        [Fact]
        public void Test() {
            Assert.Null(this.Mapper.From<string>(null).To<string>());
            Assert.Null(this.Mapper.From<string>(null).To<int?>());
            Assert.Null(this.Mapper.From<string>(null).To<Person>());
        }
    }
}

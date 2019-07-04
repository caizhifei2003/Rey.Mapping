using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class DateTimeTest : TestBase {
        [Fact]
        public void Test() {
            var value = new DateTime(2019, 1, 1, 1, 1, 1);
            var content = value.ToString();

            Assert.Equal(value, this.Mapper.From(value).To<DateTime>());
            Assert.Equal(content, this.Mapper.From(value).To<string>());
        }
    }
}

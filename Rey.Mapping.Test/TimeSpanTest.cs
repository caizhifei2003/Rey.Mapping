using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class TimeSpanTest : TestBase {
        [Fact]
        public void Test() {
            var value = TimeSpan.FromMinutes(30);
            var content = value.ToString();

            Assert.Equal(value, this.Mapper.From(value).To<TimeSpan>());
            Assert.Equal(content, this.Mapper.From(value).To<string>());
        }
    }
}

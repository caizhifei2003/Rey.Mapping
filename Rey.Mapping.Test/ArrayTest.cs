using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rey.Mapping.Test {
    public class ArrayTest : TestBase {
        [Fact]
        public void Test() {
            var arr = new[] { 1, 2, 3, 4, 5 };

            Assert.Equal(arr, this.Mapper.From(arr).To<int[]>());
            Assert.Equal(arr, this.Mapper.From(arr).To<IEnumerable<int>>());

            Assert.Equal(arr, this.Mapper.From(arr.ToList()).To<int[]>());
            Assert.Equal(arr, this.Mapper.From(arr.ToList()).To<IEnumerable<int>>());
        }
    }
}

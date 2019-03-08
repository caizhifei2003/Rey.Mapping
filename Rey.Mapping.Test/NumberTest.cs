using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class NumberTest : TestBase {
        [Theory]
        [InlineData(SByte.MinValue, SByte.MinValue)]
        [InlineData(SByte.MaxValue, SByte.MaxValue)]
        [InlineData(Int16.MinValue, Int16.MinValue)]
        [InlineData(Int16.MaxValue, Int16.MaxValue)]
        [InlineData(Int32.MinValue, Int32.MinValue)]
        [InlineData(Int32.MaxValue, Int32.MaxValue)]
        public void TestInt64Cast<T>(T from, Int64 expected) {
            var to = this.Mapper.From(from).To<Int64>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(SByte.MinValue, SByte.MinValue)]
        [InlineData(SByte.MaxValue, SByte.MaxValue)]
        [InlineData(Int16.MinValue, Int16.MinValue)]
        [InlineData(Int16.MaxValue, Int16.MaxValue)]
        public void TestInt32Cast<T>(T from, Int32 expected) {
            var to = this.Mapper.From(from).To<Int32>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(SByte.MinValue, SByte.MinValue)]
        [InlineData(SByte.MaxValue, SByte.MaxValue)]
        public void TestInt16Cast<T>(T from, Int16 expected) {
            var to = this.Mapper.From(from).To<Int16>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(Byte.MinValue, Byte.MinValue)]
        [InlineData(Byte.MaxValue, Byte.MaxValue)]
        [InlineData(UInt16.MinValue, UInt16.MinValue)]
        [InlineData(UInt16.MaxValue, UInt16.MaxValue)]
        [InlineData(UInt32.MinValue, UInt32.MinValue)]
        [InlineData(UInt32.MaxValue, UInt32.MaxValue)]
        public void TestUInt64Cast<T>(T from, UInt64 expected) {
            var to = this.Mapper.From(from).To<UInt64>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(Byte.MinValue, Byte.MinValue)]
        [InlineData(Byte.MaxValue, Byte.MaxValue)]
        [InlineData(UInt16.MinValue, UInt16.MinValue)]
        [InlineData(UInt16.MaxValue, UInt16.MaxValue)]
        public void TestUInt32Cast<T>(T from, UInt32 expected) {
            var to = this.Mapper.From(from).To<UInt32>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(Byte.MinValue, Byte.MinValue)]
        [InlineData(Byte.MaxValue, Byte.MaxValue)]
        public void TestUInt16Cast<T>(T from, UInt16 expected) {
            var to = this.Mapper.From(from).To<UInt16>();
            Assert.Equal(expected, to);
        }
    }
}

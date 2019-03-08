using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class BasicTest : TestBase {
        [Theory]
        [InlineData("this is test string", "this is test string")]
        public void TestString(string from, string expected) {
            var to = this.Mapper.From(from).To<string>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData('x', 'x')]
        public void TestChar(char from, char expected) {
            var to = this.Mapper.From(from).To<char>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(SByte.MinValue, SByte.MinValue)]
        [InlineData(SByte.MaxValue, SByte.MaxValue)]
        [InlineData(-1, -1)]
        public void TestInt8(sbyte from, sbyte expected) {
            var to = this.Mapper.From(from).To<sbyte>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(Int16.MinValue, Int16.MinValue)]
        [InlineData(Int16.MaxValue, Int16.MaxValue)]
        [InlineData(-1, -1)]
        public void TestInt16(Int16 from, Int16 expected) {
            var to = this.Mapper.From(from).To<Int16>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(Int32.MinValue, Int32.MinValue)]
        [InlineData(Int32.MaxValue, Int32.MaxValue)]
        [InlineData(-1, -1)]
        public void TestInt32(Int32 from, Int32 expected) {
            var to = this.Mapper.From(from).To<Int32>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(Int64.MinValue, Int64.MinValue)]
        [InlineData(Int64.MaxValue, Int64.MaxValue)]
        [InlineData(-1, -1)]
        public void TestInt64(Int64 from, Int64 expected) {
            var to = this.Mapper.From(from).To<Int64>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(byte.MinValue, byte.MinValue)]
        [InlineData(byte.MaxValue, byte.MaxValue)]
        [InlineData(1, 1)]
        public void TestUInt8(byte from, byte expected) {
            var to = this.Mapper.From(from).To<byte>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(UInt16.MinValue, UInt16.MinValue)]
        [InlineData(UInt16.MaxValue, UInt16.MaxValue)]
        [InlineData(1, 1)]
        public void TestUInt16(UInt16 from, UInt16 expected) {
            var to = this.Mapper.From(from).To<UInt16>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(UInt32.MinValue, UInt32.MinValue)]
        [InlineData(UInt32.MaxValue, UInt32.MaxValue)]
        [InlineData(1, 1)]
        public void TestUInt32(UInt32 from, UInt32 expected) {
            var to = this.Mapper.From(from).To<UInt32>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(UInt64.MinValue, UInt64.MinValue)]
        [InlineData(UInt64.MaxValue, UInt64.MaxValue)]
        [InlineData(1, 1)]
        public void TestUInt64(UInt64 from, UInt64 expected) {
            var to = this.Mapper.From(from).To<UInt64>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(float.MinValue, float.MinValue)]
        [InlineData(float.MaxValue, float.MaxValue)]
        [InlineData(1.23, 1.23)]
        public void TestFloat(float from, float expected) {
            var to = this.Mapper.From(from).To<float>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(double.MinValue, double.MinValue)]
        [InlineData(double.MaxValue, double.MaxValue)]
        [InlineData(1.23, 1.23)]
        public void TestDouble(double from, double expected) {
            var to = this.Mapper.From(from).To<double>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [InlineData(1.23, 1.23)]
        public void TestDecimal(decimal from, decimal expected) {
            var to = this.Mapper.From(from).To<decimal>();
            Assert.Equal(expected, to);
        }
    }
}

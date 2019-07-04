using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class NumberTest : TestBase {
        [Fact]
        public void TestInt() {
            Assert.Equal((SByte)1, this.Mapper.From<SByte>(1).To<SByte>());
            Assert.Equal((Int16)1, this.Mapper.From<SByte>(1).To<Int16>());
            Assert.Equal((Int32)1, this.Mapper.From<SByte>(1).To<Int32>());
            Assert.Equal((Int64)1, this.Mapper.From<SByte>(1).To<Int64>());

            Assert.Equal((Int16)1, this.Mapper.From<Int16>(1).To<Int16>());
            Assert.Equal((Int32)1, this.Mapper.From<Int16>(1).To<Int32>());
            Assert.Equal((Int64)1, this.Mapper.From<Int16>(1).To<Int64>());

            Assert.Equal((Int32)1, this.Mapper.From<Int32>(1).To<Int32>());
            Assert.Equal((Int64)1, this.Mapper.From<Int32>(1).To<Int64>());

            Assert.Equal((Int64)1, this.Mapper.From<Int64>(1).To<Int64>());
        }

        [Fact]
        public void TestUInt() {
            Assert.Equal((Byte)1, this.Mapper.From<Byte>(1).To<Byte>());
            Assert.Equal((UInt16)1, this.Mapper.From<Byte>(1).To<UInt16>());
            Assert.Equal((UInt32)1, this.Mapper.From<Byte>(1).To<UInt32>());
            Assert.Equal((UInt64)1, this.Mapper.From<Byte>(1).To<UInt64>());

            Assert.Equal((UInt16)1, this.Mapper.From<UInt16>(1).To<UInt16>());
            Assert.Equal((UInt32)1, this.Mapper.From<UInt16>(1).To<UInt32>());
            Assert.Equal((UInt64)1, this.Mapper.From<UInt16>(1).To<UInt64>());

            Assert.Equal((UInt32)1, this.Mapper.From<UInt32>(1).To<UInt32>());
            Assert.Equal((UInt64)1, this.Mapper.From<UInt32>(1).To<UInt64>());

            Assert.Equal((UInt64)1, this.Mapper.From<UInt64>(1).To<UInt64>());
        }

        [Fact]
        public void TestFloat() {
            Assert.Equal((Single)1.23, this.Mapper.From((Single)1.23).To<Single>());
            Assert.Equal((Double)1.23, this.Mapper.From((Single)1.23).To<Double>());
            Assert.Equal((Double)1.23, this.Mapper.From((Double)1.23).To<Double>());
            Assert.Equal((Decimal)1.23, this.Mapper.From((Decimal)1.23).To<Decimal>());
        }

        [Fact]
        public void TestToString() {
            Assert.Equal("1", this.Mapper.From((SByte)1).To<string>());
            Assert.Equal("1", this.Mapper.From((Int16)1).To<string>());
            Assert.Equal("1", this.Mapper.From((Int32)1).To<string>());
            Assert.Equal("1", this.Mapper.From((Int64)1).To<string>());

            Assert.Equal("1", this.Mapper.From((Byte)1).To<string>());
            Assert.Equal("1", this.Mapper.From((UInt16)1).To<string>());
            Assert.Equal("1", this.Mapper.From((UInt32)1).To<string>());
            Assert.Equal("1", this.Mapper.From((UInt64)1).To<string>());

            Assert.Equal("1.23", this.Mapper.From((Single)1.23).To<string>());
            Assert.Equal("1.23", this.Mapper.From((Double)1.23).To<string>());
            Assert.Equal("1.23", this.Mapper.From((Decimal)1.23).To<string>());
        }
    }
}

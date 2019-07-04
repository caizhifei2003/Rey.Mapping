using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class NullableTest : TestBase {
        [Fact]
        public void Test() {
            Assert.Equal((SByte?)1, this.Mapper.From((SByte?)1).To<SByte?>());
            Assert.Equal((SByte)1, this.Mapper.From((SByte?)1).To<SByte>());
            Assert.Equal((SByte?)1, this.Mapper.From((SByte)1).To<SByte?>());

            Assert.Equal((Int16?)1, this.Mapper.From((Int16?)1).To<Int16?>());
            Assert.Equal((Int16)1, this.Mapper.From((Int16?)1).To<Int16>());
            Assert.Equal((Int16?)1, this.Mapper.From((Int16)1).To<Int16?>());

            Assert.Equal((Int32?)1, this.Mapper.From((Int32?)1).To<Int32?>());
            Assert.Equal((Int32)1, this.Mapper.From((Int32?)1).To<Int32>());
            Assert.Equal((Int32?)1, this.Mapper.From((Int32)1).To<Int32?>());

            Assert.Equal((Int64?)1, this.Mapper.From((Int64?)1).To<Int64?>());
            Assert.Equal((Int64)1, this.Mapper.From((Int64?)1).To<Int64>());
            Assert.Equal((Int64?)1, this.Mapper.From((Int64)1).To<Int64?>());

            Assert.Equal((Byte?)1, this.Mapper.From((Byte?)1).To<Byte?>());
            Assert.Equal((Byte)1, this.Mapper.From((Byte?)1).To<Byte>());
            Assert.Equal((Byte?)1, this.Mapper.From((Byte)1).To<Byte?>());

            Assert.Equal((UInt16?)1, this.Mapper.From((UInt16?)1).To<UInt16?>());
            Assert.Equal((UInt16)1, this.Mapper.From((UInt16?)1).To<UInt16>());
            Assert.Equal((UInt16?)1, this.Mapper.From((UInt16)1).To<UInt16?>());

            Assert.Equal((UInt32?)1, this.Mapper.From((UInt32?)1).To<UInt32?>());
            Assert.Equal((UInt32)1, this.Mapper.From((UInt32?)1).To<UInt32>());
            Assert.Equal((UInt32?)1, this.Mapper.From((UInt32)1).To<UInt32?>());

            Assert.Equal((UInt64?)1, this.Mapper.From((UInt64?)1).To<UInt64?>());
            Assert.Equal((UInt64)1, this.Mapper.From((UInt64?)1).To<UInt64>());
            Assert.Equal((UInt64?)1, this.Mapper.From((UInt64)1).To<UInt64?>());

            Assert.Equal((Single?)1, this.Mapper.From((Single?)1).To<Single?>());
            Assert.Equal((Single)1, this.Mapper.From((Single?)1).To<Single>());
            Assert.Equal((Single?)1, this.Mapper.From((Single)1).To<Single?>());

            Assert.Equal((Double?)1, this.Mapper.From((Double?)1).To<Double?>());
            Assert.Equal((Double)1, this.Mapper.From((Double?)1).To<Double>());
            Assert.Equal((Double?)1, this.Mapper.From((Double)1).To<Double?>());

            Assert.Equal((Decimal?)1, this.Mapper.From((Decimal?)1).To<Decimal?>());
            Assert.Equal((Decimal)1, this.Mapper.From((Decimal?)1).To<Decimal>());
            Assert.Equal((Decimal?)1, this.Mapper.From((Decimal)1).To<Decimal?>());

            var now = DateTime.Now;
            Assert.Equal(now, this.Mapper.From<DateTime?>(now).To<DateTime?>());
            Assert.Equal(now, this.Mapper.From<DateTime?>(now).To<DateTime>());
            Assert.Equal(now, this.Mapper.From<DateTime>(now).To<DateTime?>());

            var span = TimeSpan.FromMinutes(30);
            Assert.Equal(span, this.Mapper.From<TimeSpan?>(span).To<TimeSpan?>());
            Assert.Equal(span, this.Mapper.From<TimeSpan?>(span).To<TimeSpan>());
            Assert.Equal(span, this.Mapper.From<TimeSpan>(span).To<TimeSpan?>());
        }
    }
}

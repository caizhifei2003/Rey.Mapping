using Rey.Mapping.Test.Models;
using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class StringTest : TestBase {
        [Fact]
        public void Test() {
            Assert.Equal("test", this.Mapper.From("test").To<string>());
            Assert.Equal(new DateTime(2019, 1, 1, 1, 1, 1), this.Mapper.From("2019-01-01 01:01:01").To<DateTime>());
            Assert.Equal(TimeSpan.FromMinutes(30), this.Mapper.From("00:30:00").To<TimeSpan>());

            Assert.Equal((SByte)1, this.Mapper.From("1").To<SByte>());
            Assert.Equal((Int16)1, this.Mapper.From("1").To<Int16>());
            Assert.Equal((Int32)1, this.Mapper.From("1").To<Int32>());
            Assert.Equal((Int64)1, this.Mapper.From("1").To<Int64>());
            Assert.Equal((Byte)1, this.Mapper.From("1").To<Byte>());
            Assert.Equal((UInt16)1, this.Mapper.From("1").To<UInt16>());
            Assert.Equal((UInt32)1, this.Mapper.From("1").To<UInt32>());
            Assert.Equal((UInt64)1, this.Mapper.From("1").To<UInt64>());

            Assert.Equal((Single)1.23, this.Mapper.From("1.23").To<Single>());
            Assert.Equal((Double)1.23, this.Mapper.From("1.23").To<Double>());
            Assert.Equal((Decimal)1.23, this.Mapper.From("1.23").To<Decimal>());

            Assert.Equal(Gender.Male, this.Mapper.From("Male").To<Gender>());
            Assert.True(this.Mapper.From("True").To<bool>());
            Assert.True(this.Mapper.From("true").To<bool>());
            Assert.False(this.Mapper.From("False").To<bool>());
            Assert.False(this.Mapper.From("false").To<bool>());
            Assert.Equal('a', this.Mapper.From("a").To<char>());
        }
    }
}

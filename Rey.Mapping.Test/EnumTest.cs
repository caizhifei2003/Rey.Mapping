using Rey.Mapping.Test.Models;
using System;
using Xunit;

namespace Rey.Mapping.Test {
    public class EnumTest : TestBase {
        [Fact]
        public void Test() {
            Assert.Equal("Male", this.Mapper.From(Gender.Male).To<string>());
            Assert.Equal("Female", this.Mapper.From(Gender.Female).To<string>());

            Assert.Equal((SByte)1, this.Mapper.From(Gender.Male).To<SByte>());
            Assert.Equal((SByte)2, this.Mapper.From(Gender.Female).To<SByte>());

            Assert.Equal((Int16)1, this.Mapper.From(Gender.Male).To<Int16>());
            Assert.Equal((Int16)2, this.Mapper.From(Gender.Female).To<Int16>());

            Assert.Equal((Int32)1, this.Mapper.From(Gender.Male).To<Int32>());
            Assert.Equal((Int32)2, this.Mapper.From(Gender.Female).To<Int32>());

            Assert.Equal((Int64)1, this.Mapper.From(Gender.Male).To<Int64>());
            Assert.Equal((Int64)2, this.Mapper.From(Gender.Female).To<Int64>());

            Assert.Equal((Byte)1, this.Mapper.From(Gender.Male).To<Byte>());
            Assert.Equal((Byte)2, this.Mapper.From(Gender.Female).To<Byte>());

            Assert.Equal((UInt16)1, this.Mapper.From(Gender.Male).To<UInt16>());
            Assert.Equal((UInt16)2, this.Mapper.From(Gender.Female).To<UInt16>());

            Assert.Equal((UInt32)1, this.Mapper.From(Gender.Male).To<UInt32>());
            Assert.Equal((UInt32)2, this.Mapper.From(Gender.Female).To<UInt32>());

            Assert.Equal((UInt64)1, this.Mapper.From(Gender.Male).To<UInt64>());
            Assert.Equal((UInt64)2, this.Mapper.From(Gender.Female).To<UInt64>());
        }
    }
}

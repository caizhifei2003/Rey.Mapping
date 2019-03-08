using System;
using System.Collections.Generic;
using Xunit;

namespace Rey.Mapping.Test {
    public class ArrayTest : TestBase {
        [Theory]
        [MemberData(nameof(GetArrayData))]
        public void TestArray<TFrom, TTo>(TFrom[] from, TTo[] expected) {
            var to = this.Mapper.From(from).To<TTo[]>();
            Assert.Equal(expected, to);
        }

        [Theory]
        [MemberData(nameof(GetEnumerableData))]
        public void TestEnumerable<TFrom, TTo>(IEnumerable<TFrom> from, IEnumerable<TTo> expected) {
            var to = this.Mapper.From(from).To<IEnumerable<TTo>>();
            Assert.Equal(expected, to);
        }

        public static IEnumerable<object[]> GetArrayData() {
            yield return new object[] { new Int64[] { 1, 2, 3, 4, 5 }, new Int64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new Int16[] { 1, 2, 3, 4, 5 }, new Int64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new SByte[] { 1, 2, 3, 4, 5 }, new Int64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new UInt64[] { 1, 2, 3, 4, 5 }, new UInt64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new UInt32[] { 1, 2, 3, 4, 5 }, new UInt64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new UInt16[] { 1, 2, 3, 4, 5 }, new UInt64[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new Byte[] { 1, 2, 3, 4, 5 }, new UInt64[] { 1, 2, 3, 4, 5 } };
        }

        public static IEnumerable<object[]> GetEnumerableData() {
            yield return new object[] { new List<Int64> { 1, 2, 3, 4, 5 }, new List<Int64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<Int32> { 1, 2, 3, 4, 5 }, new List<Int64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<Int16> { 1, 2, 3, 4, 5 }, new List<Int64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<SByte> { 1, 2, 3, 4, 5 }, new List<Int64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<UInt64> { 1, 2, 3, 4, 5 }, new List<UInt64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<UInt32> { 1, 2, 3, 4, 5 }, new List<UInt64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<UInt16> { 1, 2, 3, 4, 5 }, new List<UInt64> { 1, 2, 3, 4, 5 } };
            yield return new object[] { new List<Byte> { 1, 2, 3, 4, 5 }, new List<UInt64> { 1, 2, 3, 4, 5 } };
        }
    }
}

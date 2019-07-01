using System;
using System.Collections.Generic;
using Xunit;

namespace Rey.Mapping.Test {
    public class StringTest : TestBase {
        [Theory]
        [MemberData(nameof(TestCharData))]
        public void TestChar(object fromValue, Type fromType, Type toType, Func<object, object, bool> equal = null) {
            var token = Serializer.Serialize(fromValue, fromType);
            var toValue = Deserializer.Deserialize(token, toType);
            equal = equal ?? new Func<object, object, bool>((from, to) => from.ToString().Equals(to.ToString()));
            Assert.True(equal(fromValue, toValue));
        }

        public static IEnumerable<object[]> TestCharData => new List<object[]> {
            new object[]{ 'a', typeof(char), typeof(char) },
            new object[]{ 'a', typeof(char), typeof(string) },
            new object[]{ "a", typeof(string), typeof(char) },
            new object[]{ "abc", typeof(string), typeof(string) },
            new object[]{ "2019/6/10 10:10:10", typeof(string), typeof(DateTime) },
            new object[]{ DateTime.Parse("2019/6/10 10:10:10"), typeof(DateTime), typeof(string) },
        };
    }
}

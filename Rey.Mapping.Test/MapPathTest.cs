using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rey.Mapping.Test {
    public class MapPathTest {
        [Theory]
        [MemberData(nameof(TestMapPathSegmentParseData))]
        public void TestMapPathSegmentParse(string content, string name, string key, string value) {
            var segment = MapPathSegment.Parse(content);
            Assert.Equal(name, segment.Name);
            Assert.Equal(key, segment.Key);
            Assert.Equal(value, segment.Value);
        }

        public static IEnumerable<object[]> TestMapPathSegmentParseData() {
            yield return new object[] { "name[key]", "name", "key", "name[key]" };
            yield return new object[] { "name", "name", null, "name" };
        }
    }
}

using System.Collections.Generic;
using Xunit;

namespace Rey.Mapping.Test {
    public class MapPathTest {
        [Fact]
        public void TestMapPath() {
            Assert.Equal("", new MapPath().PathString);
            Assert.Equal("first", new MapPath().Join("first").PathString);
            Assert.Equal("first.second", new MapPath().Join("first").Join("second").PathString);
            Assert.Equal("first.[0]", new MapPath().Join("first").Join(0).PathString);
            Assert.Equal("first.second.[1]", new MapPath().Join("first").Join("second").Join(1).PathString);
            Assert.Equal("", MapPath.Parse("").PathString);
            Assert.Equal("first", MapPath.Parse("first").PathString);
            Assert.Equal("first.second", MapPath.Parse("first.second").PathString);
            Assert.Equal("", MapPath.Parse<Person>(x => x));
            Assert.Equal("Name", MapPath.Parse<Person>(x => x.Name));
            Assert.Equal("Father.Name", MapPath.Parse<Person>(x => x.Father.Name));
            Assert.Equal("Children.[0]", MapPath.Parse<Person>(x => x.Children[0]));
            Assert.Equal("Children.[0].Name", MapPath.Parse<Person>(x => x.Children[0].Name));
            Assert.Equal("Father.Children.[0].Father.Children.[1].Name", MapPath.Parse<Person>(x => x.Father.Children[0].Father.Children[1].Name));
        }

        public class Person {
            public string Name { get; set; }
            public Person Father { get; set; }
            public List<Person> Children { get; set; }
        }
    }
}

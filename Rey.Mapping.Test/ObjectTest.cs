using System.Collections.Generic;
using Xunit;

namespace Rey.Mapping.Test {
    public class ObjectTest : TestBase {
        [Theory]
        [MemberData(nameof(GetObjectData))]
        public void TestObject(PersonFrom from, PersonTo expected) {
            var to = this.Mapper.From(from).To<PersonTo>();
            Assert.Equal(to.Name, expected.Name);
            Assert.Equal(to.Father.Name, expected.Father.Name);
            Assert.Equal(to.Children[0].Name, expected.Children[0].Name);
        }

        public class PersonFrom {
            public string Name { get; set; }
            public PersonFrom Father { get; set; }
            public List<PersonFrom> Children { get; set; } = new List<PersonFrom>();
        }

        public class PersonTo {
            public string Name { get; set; }
            public PersonFrom Father { get; set; }
            public List<PersonTo> Children { get; set; } = new List<PersonTo>();
        }

        public static IEnumerable<object[]> GetObjectData() {
            var from = new PersonFrom() { Name = "kevin", Father = new PersonFrom { Name = "father" } };
            from.Children.Add(new PersonFrom { Name = "child 1" });

            var to = new PersonTo() { Name = "kevin", Father = new PersonFrom { Name = "father" } };
            to.Children.Add(new PersonTo { Name = "child 1" });

            yield return new object[] { from, to };
        }
    }
}

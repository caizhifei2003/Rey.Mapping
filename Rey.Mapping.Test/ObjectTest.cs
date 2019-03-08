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

        [Theory]
        [MemberData(nameof(GetObjectData2))]
        public void TestObject2(PersonFrom2 from, PersonTo2 expected) {
            var to = this.Mapper.From(from)
                .To<PersonTo2>(options => {
                    options.MapTo(x => x.Father, (type, path, context) => {
                        var value = context.Values.GetValue("FatherName").GetValue();
                        return new PersonTo2() { Name = $"{value}" };
                    });

                    options.MapTo(x => x.Children, (type, path, context) => {
                        var value = context.Values.GetValue("ChildNames", 0).GetValue();
                        return new List<PersonTo2>() { new PersonTo2 { Name = $"{value}" } };
                    });
                });

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
            public PersonTo Father { get; set; }
            public List<PersonTo> Children { get; set; } = new List<PersonTo>();
        }

        public static IEnumerable<object[]> GetObjectData() {
            var from = new PersonFrom() { Name = "kevin", Father = new PersonFrom { Name = "father" } };
            from.Children.Add(new PersonFrom { Name = "child 1" });

            var to = new PersonTo() { Name = "kevin", Father = new PersonTo { Name = "father" } };
            to.Children.Add(new PersonTo { Name = "child 1" });

            yield return new object[] { from, to };
        }

        public class PersonFrom2 {
            public string Name { get; set; }
            public string FatherName { get; set; }
            public List<string> ChildNames { get; set; } = new List<string>();
        }

        public class PersonTo2 {
            public string Name { get; set; }
            public PersonTo2 Father { get; set; }
            public List<PersonTo2> Children { get; set; } = new List<PersonTo2>();
        }

        public static IEnumerable<object[]> GetObjectData2() {
            var from = new PersonFrom2() { Name = "kevin", FatherName = "father" };
            from.ChildNames.Add("child 1");

            var to = new PersonTo2() { Name = "kevin", Father = new PersonTo2 { Name = "father" } };
            to.Children.Add(new PersonTo2 { Name = "child 1" });

            yield return new object[] { from, to };
        }
    }
}

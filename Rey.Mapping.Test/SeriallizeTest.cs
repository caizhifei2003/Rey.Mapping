using Rey.Mapping.Test.Models;
using Xunit;

namespace Rey.Mapping.Test {
    public class SeriallizeTest : TestBase {
        [Fact]
        public void TestIgnore() {
            var person = new PersonFrom() {
                Name = "Person",
                Parent = new PersonFrom {
                    Name = "Person Parent",
                    Parent = new PersonFrom {
                        Name = "Person Parent Parent"
                    }
                }
            };

            var to = this.Mapper.From(person).To<PersonTo>();
            Assert.Equal("Person", to.Name);
            Assert.Equal("Person Parent", to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person, opts => {
                opts.Ignore(x => x.Name);
            }).To<PersonTo>();

            Assert.Null(to.Name);
            Assert.Equal("Person Parent", to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person, opts => {
                opts.Ignore(x => x.Parent.Name);
            }).To<PersonTo>();

            Assert.Equal("Person", to.Name);
            Assert.Null(to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person, opts => {
                opts.Ignore(x => x.Parent.Parent.Name);
            }).To<PersonTo>();

            Assert.Equal("Person", to.Name);
            Assert.Equal("Person Parent", to.Parent.Name);
            Assert.Null(to.Parent.Parent.Name);
        }

        [Fact]
        public void TestMap() {
            var person = new PersonFrom() {
                Name = "Person",
                Parent = new PersonFrom {
                    Name = "Person Parent",
                    Parent = new PersonFrom {
                        Name = "Person Parent Parent"
                    }
                }
            };

            var to = this.Mapper.From(person).To<PersonTo>();
            Assert.Equal("Person", to.Name);
            Assert.Equal("Person Parent", to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person, opts => {
                opts.Map(x => x.Name, "Parent.Name");
            }).To<PersonTo>();

            Assert.Null(to.Name);
            Assert.Equal("Person", to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person, opts => {
                opts.Map(x => x.Name, "Parent.Name", "Parent.Parent.Name");
            }).To<PersonTo>();

            Assert.Null(to.Name);
            Assert.Equal("Person", to.Parent.Name);
            Assert.Equal("Person", to.Parent.Parent.Name);
        }
    }
}

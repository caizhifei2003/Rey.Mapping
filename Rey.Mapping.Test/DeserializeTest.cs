using Rey.Mapping.Test.Models;
using Xunit;

namespace Rey.Mapping.Test {
    public class DeserializeTest : TestBase {
        [Fact]
        public void TestIngore() {
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

            to = this.Mapper.From(person).To<PersonTo>(opts => {
                opts.Ignore(x => x.Name);
            });

            Assert.Null(to.Name);
            Assert.Equal("Person Parent", to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person).To<PersonTo>(opts => {
                opts.Ignore(x => x.Parent.Name);
            });

            Assert.Equal("Person", to.Name);
            Assert.Null(to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person).To<PersonTo>(opts => {
                opts.Ignore(x => x.Parent.Parent.Name);
            });

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

            to = this.Mapper.From(person).To<PersonTo>(opts => {
                opts.Map(x => x.Name, x => x.Parent.Name);
            });

            Assert.Null(to.Name);
            Assert.Equal("Person", to.Parent.Name);
            Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);

            to = this.Mapper.From(person).To<PersonTo>(opts => {
                opts.Map(x => x.Name, x => x.Parent.Name, x => x.Parent.Parent.Name);
            });

            Assert.Null(to.Name);
            Assert.Equal("Person", to.Parent.Name);
            Assert.Equal("Person", to.Parent.Parent.Name);
        }
    }
}

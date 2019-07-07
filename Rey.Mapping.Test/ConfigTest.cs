using Rey.Mapping.Test.Models;
using Xunit;

namespace Rey.Mapping.Test {
    public class ConfigTest {
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

            {
                var mapper = new MapperBuilder()
                    .Ignore<PersonFrom>(x => x.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Null(to.Name);
                Assert.Equal("Person Parent", to.Parent.Name);
                Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .Ignore<PersonFrom>(x => x.Parent.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Equal("Person", to.Name);
                Assert.Null(to.Parent.Name);
                Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .Ignore<PersonFrom>(x => x.Parent.Parent.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Equal("Person", to.Name);
                Assert.Equal("Person Parent", to.Parent.Name);
                Assert.Null(to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .IgnoreFrom<PersonFrom>(x => x.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Null(to.Name);
                Assert.Equal("Person Parent", to.Parent.Name);
                Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .IgnoreFrom<PersonFrom>(x => x.Parent.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Equal("Person", to.Name);
                Assert.Null(to.Parent.Name);
                Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .IgnoreFrom<PersonFrom>(x => x.Parent.Parent.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Equal("Person", to.Name);
                Assert.Equal("Person Parent", to.Parent.Name);
                Assert.Null(to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .IgnoreTo<PersonTo>(x => x.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Null(to.Name);
                Assert.Equal("Person Parent", to.Parent.Name);
                Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .IgnoreTo<PersonTo>(x => x.Parent.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Equal("Person", to.Name);
                Assert.Null(to.Parent.Name);
                Assert.Equal("Person Parent Parent", to.Parent.Parent.Name);
            }

            {
                var mapper = new MapperBuilder()
                    .IgnoreTo<PersonTo>(x => x.Parent.Parent.Name)
                    .Build();

                var to = mapper.From(person).To<PersonTo>();
                Assert.Equal("Person", to.Name);
                Assert.Equal("Person Parent", to.Parent.Name);
                Assert.Null(to.Parent.Parent.Name);
            }
        }
    }
}

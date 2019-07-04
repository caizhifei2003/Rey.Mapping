using Rey.Mapping.Test.Models;
using System.Collections.Generic;
using Xunit;

namespace Rey.Mapping.Test {
    public class ObjectTest : TestBase {
        [Fact]
        public void TestBase() {
            var from = new PersonFrom() {
                Name = "Person",
                Parent = new PersonFrom { Name = "Parent" },
                Children = new List<PersonFrom> {
                    new PersonFrom{ Name = "Child 1" },
                    new PersonFrom{ Name = "Child 2" }
                },
            };

            var to = this.Mapper.From(from).To<PersonTo>();
            Assert.Equal("Person", to.Name);
            Assert.Equal("Parent", to.Parent.Name);
            Assert.Equal("Child 1", to.Children[0].Name);
            Assert.Equal("Child 2", to.Children[1].Name);
        }

        [Fact]
        public void TestIgnore() {
            var from = new PersonFrom() {
                Name = "Person",
                Parent = new PersonFrom { Name = "Parent" },
                Children = new List<PersonFrom> {
                    new PersonFrom{ Name = "Child 1" },
                    new PersonFrom{ Name = "Child 2" }
                },
            };

            var to = this.Mapper.From(from, opts => opts.Ignore(x => x.Name)).To<PersonTo>();
            Assert.Null(to.Name);
            Assert.Equal("Parent", to.Parent.Name);
            Assert.Equal("Child 1", to.Children[0].Name);
            Assert.Equal("Child 2", to.Children[1].Name);

            to = this.Mapper.From(from).To<PersonTo>(opts => opts.Ignore(x => x.Name));
            Assert.Null(to.Name);
            Assert.Equal("Parent", to.Parent.Name);
            Assert.Equal("Child 1", to.Children[0].Name);
            Assert.Equal("Child 2", to.Children[1].Name);
        }

        [Fact]
        public void TestObjectMap() {
            var from = new PersonFrom() {
                Name = "Person",
                Parent = new PersonFrom { Name = "Parent" },
                Children = new List<PersonFrom> {
                    new PersonFrom{ Name = "Child 1" },
                    new PersonFrom{ Name = "Child 2" }
                },
            };

            var to = this.Mapper.From(from, opts => opts.Map(x => x.Name, "Parent.Name")).To<PersonTo>();
            Assert.Null(to.Name);
            Assert.Equal("Person", to.Parent.Name);
            Assert.Equal("Child 1", to.Children[0].Name);
            Assert.Equal("Child 2", to.Children[1].Name);

            to = this.Mapper.From(from).To<PersonTo>(opts => opts.Map(x => x.Name, x => x.Parent.Name));
            Assert.Null(to.Name);
            Assert.Equal("Person", to.Parent.Name);
            Assert.Equal("Child 1", to.Children[0].Name);
            Assert.Equal("Child 2", to.Children[1].Name);
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var builder = new MapperBuilder();

            var mapper = new ServiceCollection().AddMapping().BuildServiceProvider().GetService<IMapper>();

            var from = new From {
                Name = "kevin",
                Age = 123,
                //Child = new From { Name = "bao" },
                //Age = 123,
                //Height = 180,
                //Fields1 = new int?[] { 1, 2, 3, null }
            };



            var to = mapper
                .From(from, options => options
                    .Map("Name", "Child.Child.Name", "Child2.Name")
                )
                .To<To>();
        }
    }

    public class From {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class To {
        public string Name { get; set; }
        public int Age { get; set; }
        public To Child { get; set; }
        public To Child2 { get; set; }
    }
}

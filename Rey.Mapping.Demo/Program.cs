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
                //Child = new From { Name = "bao" },
                //Age = 123,
                //Height = 180,
                //Fields1 = new int?[] { 1, 2, 3, null }
            };

            var to = mapper.From(from, options => options.Ignore("Child.Name")).To<To>();
        }
    }

    public class From {
        public string Name { get; set; }
        //public From Child { get; set; }
        //public From2 Child2 { get; set; }
        ////public Int32 Age { get; set; }
        ////public Int32? Height { get; set; }
        ////public Int32 Width { get; set; }
        //public IEnumerable<int?> Fields1 { get; set; }
    }

    public class To {
        public string Name { get; set; }
        //public To Child { get; set; }
        //public To Child2 { get; set; }
        ////public Int64 Age { get; set; }
        ////public Int64? Height { get; set; }
        ////public Int64? Width { get; set; }
        //public Int64?[] Fields1 { get; set; }
    }
}

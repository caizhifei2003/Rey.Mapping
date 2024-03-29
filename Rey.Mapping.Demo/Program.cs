﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var builder = new MapperBuilder();

            var services = new ServiceCollection();
            services.AddMapping();

            //var mapper = services.BuildServiceProvider().GetService<IMapper>();
            var mapper = new MapperBuilder().Build();

            var from = new From {
                Name = "kevin",
                Age = 123,
                Parent = new From { Parent = new From { Name = "parent" } }
                //Child = new From { Name = "bao" },
                //Age = 123,
                //Height = 180,
                //Fields1 = new int?[] { 1, 2, 3, null }
            };

            //var to = mapper
            //    .From(from, options => {
            //        //options.Ignore(x => x.Parent.Parent.Name);
            //        //options.Map(x => x.Name, "Child.Child.Name", "Child2.Name");
            //    })
            //    .To<To>(options => {
            //        options.Map(x => x.Name, x => x.Child.Child.Name, x => x.Child2.Name);
            //    });

            var to2 = mapper.From(TimeSpan.FromSeconds(10)).To<TimeSpan>();
        }
    }

    public enum Gender {
        Male = 1,
        Female = 2,
    }

    public class From {
        public string Name { get; set; }
        public int Age { get; set; }
        public From Parent { get; set; }
    }

    public class To {
        public string Name { get; set; }
        public int Age { get; set; }
        public To Parent { get; set; }
        public To Child { get; set; }
        public To Child2 { get; set; }
    }
}

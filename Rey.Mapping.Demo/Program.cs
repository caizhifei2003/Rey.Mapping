using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Exp = System.Linq.Expressions.Expression;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            services.AddMapping();
            var provider = services.BuildServiceProvider();
            var mapper = provider.GetService<IMapper>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<From, To>());
            var mapper2 = config.CreateMapper();
            var arr = new[] { 1, 2, 3, 4, 5 };

            var from = new From {
                Name = "kevin",
                //Child = new From { Name = "bao" },
                //Age = 123,
                //Height = 180,
                //Fields1 = new int?[] { 1, 2, 3, null }
            };

            var times = 10000;

            var begin = DateTime.Now;
            

            for (var i = 0; i < times; i++) {
                var func = Gen();
                func(arr);
            }
            Console.WriteLine(DateTime.Now - begin);

            begin = DateTime.Now;
            for (var i = 0; i < times; i++) {
                mapper.From(arr).To<int[]>();
            }
            Console.WriteLine(DateTime.Now - begin);
            Console.ReadLine();

            //{
            //    var value = mapper.From("2019-06-10 10:10:10").To<DateTime>();
            //}

            //{
            //    var from = new From {
            //        //Name = "kevin",
            //        //Child = new From { Name = "bao" },
            //        //Age = 123,
            //        //Height = 180,
            //        Fields1 = new int?[] { 1, 2, 3, null }
            //    };
            //    var to = mapper.From(from, options => options.Ignore("Child.Name")).To<To>();
            //}
        }

        public static Func<int[], int[]> Gen() {
            var ctor = typeof(int[]).GetConstructor(new[] { typeof(int) });
            var get = typeof(int[]).GetMethod("Get", new[] { typeof(int) });
            var set = typeof(int[]).GetMethod("Set", new[] { typeof(int), typeof(int) });

            var p1 = Exp.Parameter(typeof(int[]));
            var v1 = Exp.Variable(typeof(int[]));
            var v2 = Exp.Variable(typeof(int));
            var @break = Exp.Label();

            var block = Exp.Block(
                new[] { v1, v2 },
                Exp.Assign(v1, Exp.New(ctor, Exp.Property(p1, "Length"))),
                Exp.Assign(v2, Exp.Constant(0)),
                Exp.Loop(
                    Exp.IfThenElse(
                        Exp.LessThan(v2, Exp.Property(p1, "Length")),
                        Exp.Block(
                            Exp.Call(v1, set, v2, Exp.Call(p1, get, v2)),
                            Exp.AddAssign(v2, Exp.Constant(1))
                            ),
                        Exp.Break(@break)
                        ),
                    @break),
                v1
                );

            return Exp.Lambda<Func<int[], int[]>>(block, new ParameterExpression[] { p1 }).Compile();
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

    public class From2 {
        public string Name { get; set; }
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

    public class To2 {
        public string Name { get; set; }
    }
}

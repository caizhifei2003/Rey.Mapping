using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;
using Exp = System.Linq.Expressions.Expression;

namespace Rey.Mapping {
    public class AndExpressionTest {
        public int Times { get; }

        public AndExpressionTest(int times = 10000) {
            this.Times = times;
        }

        public void Run() {
            var arr = new[] { 1, 2, 3, 4, 5 };
            var mapper = new MapperBuilder().Build();

            var begin = DateTime.Now;
            for (var i = 0; i < this.Times; i++) {
                GenerateCopyExpression()(arr);
            }
            Console.WriteLine($"expression: {DateTime.Now - begin}");

            begin = DateTime.Now;
            for (var i = 0; i < this.Times; i++) {
                mapper.From(arr).To<int[]>();
            }
            Console.WriteLine($"reflection mapper: {DateTime.Now - begin}");
        }

        private static Func<int[], int[]> GenerateCopyExpression() {
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
}

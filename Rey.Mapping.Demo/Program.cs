using System;

namespace Rey.Mapping.Demo {
    class Program {
        static void Main(string[] args) {
            var mapper = new MapperBuilder()
                .FromMapper<FromInt32Mapper>()
                .FromMapper<FromClassMapper>()
                .ToMapper<ToInt32Mapper>()
                .ToMapper<ToStringMapper>()
                .Build();
            //var ret = mapper.From(32).To<string>().Map();
            var from = new Person() { Name = "kevin" };
            var contract = mapper.From(from).MapToContract();
        }
    }

    public class Person {
        public string Name { get; set; }
    }
}

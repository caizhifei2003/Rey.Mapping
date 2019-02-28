using System;

namespace Rey.Mapping.Demo {
    class Program {
        static void Main(string[] args) {
            var mapper = new MapperBuilder()
                .FromMapper<FromInt32Mapper>()
                .ToMapper<ToInt32Mapper>()
                .ToMapper<ToStringMapper>()
                .Build();
            var ret = mapper.From(32).To<string>().Map();
        }
    }
}

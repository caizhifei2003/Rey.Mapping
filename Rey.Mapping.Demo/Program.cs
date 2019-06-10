using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var options = new MapperOptions();

            var converters = new List<IMapConverter>();
            converters.Add(new MapStringConverter());

            var deserializer = new MapDeserializer(converters);
            var serializer = new MapSerializer(converters, deserializer);

            var mapper = new Mapper(options, serializer);
            var node = mapper.From("2019-06-10 10:10:10");
            var origin = node.To<DateTime>();

            Console.WriteLine("Hello World!");
        }
    }
}

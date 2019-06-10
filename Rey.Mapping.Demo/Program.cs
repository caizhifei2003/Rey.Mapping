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
            var node = mapper.From("t");
            var origin = node.To<char>();



            Console.WriteLine("Hello World!");
        }
    }
}

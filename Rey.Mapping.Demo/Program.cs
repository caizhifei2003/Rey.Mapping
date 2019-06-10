using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var options = new MapperOptions();
            var sOptions = new MapSerializeOptions();
            var dOptions = new MapDeserializeOptions();

            var converters = new List<IMapConverter>();
            converters.Add(new MapStringConverter());

            var deserializer = new MapDeserializer(converters);
            var serializer = new MapSerializer(converters, deserializer);

            var mapper = new Mapper(options, serializer);
            var node = mapper.From("test");
            var origin = node.To<string>();



            Console.WriteLine("Hello World!");
        }
    }
}

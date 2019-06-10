using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var options = new MapperOptions();
            var sOptions = new SerializeOptions();
            var dOptions = new DeserializeOptions();

            var converters = new List<IMapConverter>();
            converters.Add(new MapStringConverter());

            var deserializer = new MapDeserializer();
            var serializer = new MapSerializer(converters, deserializer);

            var mapper = new Mapper(options, serializer);
            var node = mapper.From("test", typeof(string), sOptions);
            var origin = node.To(typeof(string), dOptions);

            Console.WriteLine("Hello World!");
        }
    }
}

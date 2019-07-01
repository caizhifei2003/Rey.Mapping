using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var options = new MapperOptions();

            var converters = new List<IMapConverter>();
            converters.Add(new MapStringConverter());

            var serializer = new MapSerializer(converters);
            var deserializer = new MapDeserializer(converters);

            var token = serializer.Serialize("2019-06-10 10:10:10", typeof(string), new MapSerializeOptions());
            var origin = deserializer.Deserialize(token, typeof(DateTime), new MapDeserializeOptions());

            Console.WriteLine("Hello World!");
        }
    }
}

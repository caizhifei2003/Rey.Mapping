﻿using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static List<IMapConverter> Converters { get; } = new List<IMapConverter> {
            new MapStringConverter(),
            new MapObjectConverter(),
        };

        static IMapSerializer Serializer { get; } = new MapSerializer(Converters);
        static IMapDeserializer Deserializer { get; } = new MapDeserializer(Converters);

        static void Main(string[] args) {
            {
                var token = Serializer.Serialize("2019-06-10 10:10:10", typeof(string), new MapSerializeOptions());
                var origin = Deserializer.Deserialize(token, typeof(DateTime), new MapDeserializeOptions());
            }

            {
                var token = Serializer.Serialize(new From { Name = "kevin", Child = new From2 { Name = "bao" } }, typeof(From), new MapSerializeOptions());
                var origin = Deserializer.Deserialize(token, typeof(To), new MapDeserializeOptions());
            }
        }
    }

    public class From {
        public string Name { get; set; }
        public From2 Child { get; set; }
    }

    public class From2 {
        public string Name { get; set; }
    }

    public class To {
        public string Name { get; set; }
        public To2 Child { get; set; }
    }

    public class To2 {
        public string Name { get; set; }
    }
}

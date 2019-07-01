using Microsoft.Extensions.DependencyInjection;
using Rey.Mapping.Configuration;
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
        static IMapper Mapper { get; } = new Mapper(new MapperOptions(), Serializer, Deserializer);

        static void Main(string[] args) {
            var services = new ServiceCollection();
            services.AddMapping();
            var provider = services.BuildServiceProvider();
            var mapper = provider.GetService<IMapper>();

            {
                var value = mapper.From("2019-06-10 10:10:10").To<DateTime>();
            }

            {
                var from = new From {
                    //Name = "kevin",
                    //Child = new From2 { Name = "bao" },
                    //Age = 123,
                    Height = 180,
                };
                var to = mapper.From(from).To<To>();
            }
        }
    }

    public class From {
        //public string Name { get; set; }
        //public From2 Child { get; set; }
        //public From2 Child2 { get; set; }
        //public Int32 Age { get; set; }
        public Int32? Height { get; set; }
        //public Int32 Width { get; set; }
    }

    public class From2 {
        public string Name { get; set; }
    }

    public class To {
        //public string Name { get; set; }
        //public To2 Child { get; set; }
        //public To2 Child2 { get; set; }
        //public Int64 Age { get; set; }
        public Int64? Height { get; set; }
        //public Int64? Width { get; set; }
    }

    public class To2 {
        public string Name { get; set; }
    }
}

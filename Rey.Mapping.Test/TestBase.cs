using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping.Test {
    public abstract class TestBase {
        protected List<IMapConverter> Converters { get; } = new List<IMapConverter> {
            new MapStringConverter(),
            new MapObjectConverter(),
        };

        protected IMapSerializer Serializer => new MapSerializer(Converters);
        protected IMapDeserializer Deserializer => new MapDeserializer(Converters);
    }
}

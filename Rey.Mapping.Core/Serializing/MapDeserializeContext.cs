using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class MapDeserializeContext : IMapDeserializeContext {
        private readonly IMapDeserializer _deserializer;

        public MapDeserializeContext(IMapDeserializer deserializer) {
            this._deserializer = deserializer;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return this._deserializer.Deserialize(token, toType, options);
        }
    }
}

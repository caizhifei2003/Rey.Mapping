using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;
        private readonly IMapDeserializer _deserializer;

        public MapSerializeContext(IMapSerializer serializer, IMapDeserializer deserializer) {
            this._serializer = serializer;
            this._deserializer = deserializer;
        }

        public IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return this._serializer.Serialize(fromValue, fromType, options);
        }

        public IMapNode CreateNode(IMapToken token) {
            return new MapNode(token, this._deserializer);
        }
    }
}

using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;

        public MapSerializeContext(IMapSerializer serializer) {
            this._serializer = serializer;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return this._serializer.Serialize(fromValue, fromType, options);
        }
    }
}

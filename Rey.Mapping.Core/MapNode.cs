using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class MapNode : IMapNode {
        private readonly IMapDeserializer _deserializer;

        public IMapToken Token { get; }

        public MapNode(IMapToken token, IMapDeserializer deserializer) {
            this.Token = token;
            this._deserializer = deserializer;
        }

        public object To(Type toType, IMapDeserializeOptions options) {
            return this._deserializer.Deserialize(this, toType, options);
        }
    }
}

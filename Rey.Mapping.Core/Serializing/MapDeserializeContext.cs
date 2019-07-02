using System;

namespace Rey.Mapping {
    public class MapDeserializeContext : IMapDeserializeContext {
        private readonly IMapDeserializer _deserializer;

        public MapPath Path { get; } = new MapPath();

        public MapDeserializeContext(IMapDeserializer deserializer) {
            this._deserializer = deserializer;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, string segment = null) {
            try {
                if (segment != null) this.Path.Push(segment);
                return this._deserializer.Deserialize(token, toType, options, this);
            } finally {
                if (segment != null) this.Path.Pop();
            }
        }
    }
}

using System;

namespace Rey.Mapping {
    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;

        public MapPath Path { get; } = new MapPath();

        public MapSerializeContext(IMapSerializer serializer) {
            this._serializer = serializer;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, string segment = null) {
            try {
                if (segment != null) this.Path.Push(segment);
                return this._serializer.Serialize(fromValue, fromType, options, this);
            } finally {
                if (segment != null) this.Path.Pop();
            }
        }
    }
}

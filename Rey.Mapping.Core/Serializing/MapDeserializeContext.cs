using System;

namespace Rey.Mapping {
    public class MapDeserializeContext : IMapDeserializeContext {
        private readonly IMapDeserializer _deserializer;

        public MapPath Path { get; } = new MapPath();
        public IMapTable Table { get; }

        public MapDeserializeContext(IMapDeserializer deserializer, IMapTable table) {
            this._deserializer = deserializer;
            this.Table = table;
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options) {
            //! ignore path;
            if (options.IsIgnore(path))
                return null;

            return this._deserializer.Deserialize(path, toType, options, this);
        }
    }
}

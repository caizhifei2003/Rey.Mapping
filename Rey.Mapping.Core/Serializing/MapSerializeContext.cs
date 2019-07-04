using System;

namespace Rey.Mapping {
    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;

        public MapPath Path { get; } = new MapPath();
        public IMapTable Table { get; }

        public MapSerializeContext(IMapSerializer serializer, IMapTable table) {
            this._serializer = serializer;
            this.Table = table;
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options) {
            //! ignore path
            if (options.IsIgnore(path))
                return;

            this._serializer.Serialize(path, fromValue, fromType, options, this);
        }
    }
}

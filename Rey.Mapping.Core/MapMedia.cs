using System;

namespace Rey.Mapping {
    public class MapMedia : IMapMedia {
        private readonly IMapTable _table;
        private readonly IMapDeserializer _deserializer;

        public MapMedia(IMapTable table, IMapDeserializer deserializer) {
            this._table = table;
            this._deserializer = deserializer;
        }

        public object To(Type toType, IMapDeserializeOptions options) {
            var context = new MapDeserializeContext(this._deserializer, this._table);
            return this._deserializer.Deserialize(MapPath.Root, toType, options, context);
        }
    }
}

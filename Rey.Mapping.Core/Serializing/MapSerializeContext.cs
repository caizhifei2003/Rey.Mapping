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

            var mapPaths = options.GetMapPaths(path);
            foreach (var mapPath in mapPaths) {
                this.EnsureParentExist(mapPath.Parent());

                this._serializer.Serialize(mapPath, fromValue, fromType, options, this);
            }
        }

        private void EnsureParentExist(MapPath path) {
            if (this.Table.ContainsPath(path))
                return;

            this.EnsureParentExist(path.Parent());
            this.Table.AddToken(path, new MapObjectToken());
        }
    }
}

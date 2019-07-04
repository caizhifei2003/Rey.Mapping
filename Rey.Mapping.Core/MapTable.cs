using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapTable : SortedDictionary<MapPath, IMapToken>, IMapTable {
        private MapTable(IDictionary<MapPath, IMapToken> dic)
            : base(dic) {
        }

        public MapTable()
            : base() {
        }

        public void AddToken(MapPath path, IMapToken token) {
            this.Add(path, token);
        }

        private void SetToken(MapPath path, IMapToken token) {
            this[path] = token;
            for (var parent = path.Parent(); parent != null && !this.ContainsPath(parent); parent = parent.Parent()) {
                this.Add(parent, new MapObjectToken());
            }
        }

        public IMapToken GetToken(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this.TryGetValue(path, out var token) ? token : null;
        }

        public bool ContainsPath(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this.ContainsKey(path);
        }

        public IEnumerable<KeyValuePair<MapPath, IMapToken>> GetChildren(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this.Where(x => path.Equals(x.Key.Parent()));
        }

        public IMapTable AfterSerialize(IMapSerializeOptions options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var table = new MapTable(this);
            var maps = options.GetMaps();
            foreach (var map in maps) {
                var token = table.GetToken(map.Key);
                table.Remove(map.Key);
                foreach (var path in map.Value) {
                    table.SetToken(path, token);
                }
            }

            return table;
        }

        public IMapTable BeforeDeserialize(IMapDeserializeOptions options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var table = new MapTable(this);
            var maps = options.GetMaps();
            foreach (var map in maps) {
                var token = table.GetToken(map.Key);
                table.Remove(map.Key);
                foreach (var path in map.Value) {
                    table.SetToken(path, token);
                }
            }

            return table;
        }
    }
}

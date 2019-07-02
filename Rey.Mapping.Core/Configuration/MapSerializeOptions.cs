using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping.Configuration {
    public class MapSerializeOptions : IMapSerializeOptions {
        private readonly List<MapPath> _ignores = new List<MapPath>();
        private readonly Dictionary<MapPath, MapPath> _maps = new Dictionary<MapPath, MapPath>();

        public IMapSerializeOptions Ignore(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            this._ignores.Add(path);
            return this;
        }

        public bool IsIgnore(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this._ignores.Any(p => p.Equals(path));
        }

        public IMapSerializeOptions Map(MapPath from, MapPath to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            this._maps.Add(from, to);
            return this;
        }

        public MapPath MapTo(MapPath from) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (this._maps.TryGetValue(from, out var to))
                return to;

            return from;
        }
    }
}

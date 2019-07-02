using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping.Configuration {
    public class MapDeserializeOptions : IMapDeserializeOptions {
        private readonly List<MapPath> _ignores = new List<MapPath>();

        public IMapDeserializeOptions Ignore(MapPath path) {
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
    }
}

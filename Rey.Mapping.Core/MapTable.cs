using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapTable : Dictionary<MapPath, IMapToken>, IMapTable {
        public void AddToken(MapPath path, IMapToken token) {
            this.Add(path, token);
        }

        public IMapToken GetToken(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this.TryGetValue(path, out var token) ? token : null;
        }

        public IEnumerable<KeyValuePair<MapPath, IMapToken>> GetChildren(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this.Where(x => path.Equals(x.Key.Parent()));
        }
    }
}

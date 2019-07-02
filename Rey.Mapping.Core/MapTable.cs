using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapTable : Dictionary<MapPath, IMapToken>, IMapTable {
        public void AddToken(MapPath path, IMapToken token) {
            this.Add(path, token);
        }

        public IMapToken GetToken(MapPath path) {
            return this.TryGetValue(path, out var token) ? token : null;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapValueTable {
        public Dictionary<string, MapValue> Values { get; } = new Dictionary<string, MapValue>();

        public MapValueTable AddValue(MapPath path, MapValue value) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            this.Values.Add(path.PathString, value);
            return this;
        }

        public MapValue GetValue(MapPath path) {
            return this.Values[path.PathString];
        }
    }
}

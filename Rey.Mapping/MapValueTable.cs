﻿using System;
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

        public bool HasValue(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this.Values.ContainsKey(path.PathString);
        }

        public MapValue GetValue(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (!this.Values.TryGetValue(path.PathString, out var value))
                return null;

            return value;
        }
    }
}

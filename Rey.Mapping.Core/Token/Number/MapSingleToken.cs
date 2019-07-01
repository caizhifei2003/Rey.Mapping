using System;

namespace Rey.Mapping {
    public class MapSingleToken : MapValueToken<Single> {
        public MapSingleToken(Single value, Type type)
            : base(value, type) {
        }
    }
}

using System;

namespace Rey.Mapping {
    public class MapSingleToken : MapValueToken<Single> {
        public MapSingleToken(Single fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

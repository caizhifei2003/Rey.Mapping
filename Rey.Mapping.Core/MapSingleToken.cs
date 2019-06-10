using System;

namespace Rey.Mapping {
    public class MapSingleToken : MapToken<Single> {
        public MapSingleToken(Single fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

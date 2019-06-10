using System;

namespace Rey.Mapping {
    public class MapBoolToken : MapToken<bool> {
        public MapBoolToken(bool fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

using System;

namespace Rey.Mapping {
    public class MapBoolToken : MapValueToken<bool> {
        public MapBoolToken(bool fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

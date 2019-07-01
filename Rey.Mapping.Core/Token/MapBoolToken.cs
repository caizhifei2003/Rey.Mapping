using System;

namespace Rey.Mapping {
    public class MapBoolToken : MapValueToken<bool> {
        public MapBoolToken(bool value, Type type)
            : base(value, type) {
        }
    }
}

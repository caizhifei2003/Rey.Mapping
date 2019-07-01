using System;

namespace Rey.Mapping {
    public class MapUInt64Token : MapValueToken<UInt64> {
        public MapUInt64Token(UInt64 value, Type type)
            : base(value, type) {
        }
    }
}

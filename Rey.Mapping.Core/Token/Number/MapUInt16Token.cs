using System;

namespace Rey.Mapping {
    public class MapUInt16Token : MapValueToken<UInt16> {
        public MapUInt16Token(UInt16 value, Type type)
            : base(value, type) {
        }
    }
}

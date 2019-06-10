using System;

namespace Rey.Mapping {
    public class MapUInt16Token : MapValueToken<UInt16> {
        public MapUInt16Token(UInt16 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

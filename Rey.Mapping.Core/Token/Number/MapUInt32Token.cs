using System;

namespace Rey.Mapping {
    public class MapUInt32Token : MapValueToken<UInt32> {
        public MapUInt32Token(UInt32 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

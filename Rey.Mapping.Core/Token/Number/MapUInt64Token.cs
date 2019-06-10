using System;

namespace Rey.Mapping {
    public class MapUInt64Token : MapToken<UInt64> {
        public MapUInt64Token(UInt64 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

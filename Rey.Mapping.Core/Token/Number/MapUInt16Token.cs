using System;

namespace Rey.Mapping {
    public class MapUInt16Token : MapToken<UInt16> {
        public MapUInt16Token(UInt16 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

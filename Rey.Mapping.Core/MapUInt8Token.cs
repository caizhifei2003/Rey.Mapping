using System;

namespace Rey.Mapping {
    public class MapUInt8Token : MapToken<Byte> {
        public MapUInt8Token(Byte fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

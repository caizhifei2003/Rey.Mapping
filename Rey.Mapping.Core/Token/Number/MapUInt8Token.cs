using System;

namespace Rey.Mapping {
    public class MapUInt8Token : MapValueToken<Byte> {
        public MapUInt8Token(Byte value, Type type)
            : base(value, type) {
        }
    }
}

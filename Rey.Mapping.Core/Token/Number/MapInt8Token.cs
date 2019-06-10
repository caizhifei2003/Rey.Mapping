using System;

namespace Rey.Mapping {
    public class MapInt8Token : MapValueToken<SByte> {
        public MapInt8Token(SByte fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

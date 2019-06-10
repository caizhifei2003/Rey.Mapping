using System;

namespace Rey.Mapping {
    public class MapInt8Token : MapToken<SByte> {
        public MapInt8Token(SByte fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

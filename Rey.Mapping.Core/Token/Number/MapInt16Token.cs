using System;

namespace Rey.Mapping {
    public class MapInt16Token : MapValueToken<Int16> {
        public MapInt16Token(Int16 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

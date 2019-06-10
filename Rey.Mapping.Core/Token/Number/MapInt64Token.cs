using System;

namespace Rey.Mapping {
    public class MapInt64Token : MapValueToken<Int64> {
        public MapInt64Token(Int64 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

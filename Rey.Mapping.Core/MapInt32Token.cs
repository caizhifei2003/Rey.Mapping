using System;

namespace Rey.Mapping {
    public class MapInt32Token : MapToken<Int32> {
        public MapInt32Token(Int32 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

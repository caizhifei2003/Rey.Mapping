using System;

namespace Rey.Mapping {
    public class MapInt32Token : MapValueToken<Int32> {
        public MapInt32Token(Int32 value, Type type)
            : base(value, type) {
        }
    }
}

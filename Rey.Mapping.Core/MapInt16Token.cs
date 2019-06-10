using System;

namespace Rey.Mapping {
    public class MapInt16Token : MapToken<Int16> {
        public MapInt16Token(Int16 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

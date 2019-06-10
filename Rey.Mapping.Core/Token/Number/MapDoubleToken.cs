using System;

namespace Rey.Mapping {
    public class MapDoubleToken : MapValueToken<Double> {
        public MapDoubleToken(Double fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

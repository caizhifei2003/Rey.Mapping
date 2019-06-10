using System;

namespace Rey.Mapping {
    public class MapDoubleToken : MapToken<Double> {
        public MapDoubleToken(Double fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

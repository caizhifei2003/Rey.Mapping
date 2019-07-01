using System;

namespace Rey.Mapping {
    public class MapDoubleToken : MapValueToken<Double> {
        public MapDoubleToken(Double value, Type type)
            : base(value, type) {
        }
    }
}

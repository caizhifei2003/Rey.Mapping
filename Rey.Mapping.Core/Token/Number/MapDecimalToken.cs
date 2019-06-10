using System;

namespace Rey.Mapping {
    public class MapDecimalToken : MapToken<Decimal> {
        public MapDecimalToken(Decimal fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

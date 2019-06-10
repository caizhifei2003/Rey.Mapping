using System;

namespace Rey.Mapping {
    public class MapDecimalToken : MapValueToken<Decimal> {
        public MapDecimalToken(Decimal fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }
}

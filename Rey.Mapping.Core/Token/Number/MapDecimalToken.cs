using System;

namespace Rey.Mapping {
    public class MapDecimalToken : MapValueToken<Decimal> {
        public MapDecimalToken(Decimal value, Type type)
            : base(value, type) {
        }
    }
}

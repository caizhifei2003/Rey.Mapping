using System;

namespace Rey.Mapping {
    public class MapDecimalToken : MapValueToken<Decimal> {
        public MapDecimalToken(Decimal value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(Decimal));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(Decimal)))
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

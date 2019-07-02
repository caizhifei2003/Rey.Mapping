using System;

namespace Rey.Mapping {
    public class MapDecimalToken : MapNumberToken<Decimal> {
        public MapDecimalToken(Decimal value)
            : base(value) {
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

using System;

namespace Rey.Mapping {
    public class MapDecimalToken : MapNumberToken<Decimal> {
        public MapDecimalToken(Decimal value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<decimal>() || type.Equals<decimal?>()
                || type.Equals<string>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<decimal>() || type.Equals<decimal?>())
                return this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

using System;

namespace Rey.Mapping {
    public class MapDecimalValue : MapNumberValue {
        public Decimal Value { get; }

        public MapDecimalValue(Decimal value)
            : base(MapValueType.Decimal) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

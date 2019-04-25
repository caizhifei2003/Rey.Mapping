using System;

namespace Rey.Mapping {
    public class MapDoubleValue : MapNumberValue {
        public Double Value { get; }

        public MapDoubleValue(Double value)
            : base(MapValueType.Double) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }

        public override string ToString() {
            return $"{this.Value}";
        }
    }
}

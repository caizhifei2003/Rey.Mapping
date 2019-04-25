using System;

namespace Rey.Mapping {
    public class MapUInt64Value : MapNumberValue {
        public UInt64 Value { get; }

        public MapUInt64Value(UInt64 value)
            : base(MapValueType.UInt64) {
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

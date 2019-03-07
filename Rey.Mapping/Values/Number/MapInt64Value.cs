using System;

namespace Rey.Mapping {
    public class MapInt64Value : MapNumberValue {
        public Int64 Value { get; }

        public MapInt64Value(Int64 value)
            : base(MapValueType.Int64) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

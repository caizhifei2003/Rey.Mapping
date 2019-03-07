using System;

namespace Rey.Mapping {
    public class MapInt16Value : MapNumberValue {
        public Int16 Value { get; }

        public MapInt16Value(Int16 value)
            : base(MapValueType.Int16) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

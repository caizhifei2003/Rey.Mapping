using System;

namespace Rey.Mapping {
    public class MapInt32Value : MapNumberValue {
        public Int32 Value { get; }

        public MapInt32Value(Int32 value)
            : base(MapValueType.Int32) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

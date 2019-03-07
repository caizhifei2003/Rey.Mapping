using System;

namespace Rey.Mapping {
    public class MapUInt32Value : MapNumberValue {
        public UInt32 Value { get; }

        public MapUInt32Value(UInt32 value)
            : base(MapValueType.UInt32) {
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

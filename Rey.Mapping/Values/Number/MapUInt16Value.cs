using System;

namespace Rey.Mapping {
    public class MapUInt16Value : MapNumberValue {
        public UInt16 Value { get; }

        public MapUInt16Value(UInt16 value)
            : base(MapValueType.UInt16) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

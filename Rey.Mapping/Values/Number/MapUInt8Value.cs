using System;

namespace Rey.Mapping {
    public class MapUInt8Value : MapNumberValue {
        public Byte Value { get; }

        public MapUInt8Value(Byte value)
            : base(MapValueType.UInt8) {
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

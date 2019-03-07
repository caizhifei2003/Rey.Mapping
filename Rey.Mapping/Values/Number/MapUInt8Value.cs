namespace Rey.Mapping {
    public class MapUInt8Value : MapNumberValue {
        public byte Value { get; }

        public MapUInt8Value(byte value)
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

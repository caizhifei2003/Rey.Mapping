namespace Rey.Mapping {
    public class MapInt8Value : MapNumberValue {
        public sbyte Value { get; }

        public MapInt8Value(sbyte value)
            : base(MapValueType.Int8) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

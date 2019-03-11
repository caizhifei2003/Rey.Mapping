namespace Rey.Mapping {
    public class MapEnumValue : MapValue {
        public int Value { get; }

        public MapEnumValue(int value)
            : base(MapValueType.Enum) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }

        public override string ToString() {
            return this.Value.ToString();
        }
    }
}

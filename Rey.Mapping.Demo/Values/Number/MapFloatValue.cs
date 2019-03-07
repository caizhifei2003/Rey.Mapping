namespace Rey.Mapping {
    public class MapFloatValue : MapNumberValue {
        public float Value { get; }

        public MapFloatValue(float value)
            : base(MapValueType.Float) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }
    }
}

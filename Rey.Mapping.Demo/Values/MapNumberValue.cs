namespace Rey.Mapping {
    public class MapNumberValue : MapValue {
        public decimal Value { get; }

        public MapNumberValue(decimal value) {
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

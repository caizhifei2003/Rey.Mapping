namespace Rey.Mapping {
    public class MapStringValue : MapValue {
        public string Value { get; }

        public MapStringValue(string value) {
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

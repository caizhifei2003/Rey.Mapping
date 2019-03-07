namespace Rey.Mapping {
    public class MapStringValue : MapValue {
        public MapStringValue(string value)
            : base(value) {
        }

        public override string ToString() {
            return $"\"{this.Value}\"";
        }
    }
}

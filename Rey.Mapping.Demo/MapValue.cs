namespace Rey.Mapping {
    public abstract class MapValue {
        public object Value { get; }

        public MapValue(object value) {
            this.Value = value;
        }

        public override string ToString() {
            return $"{this.Value}";
        }
    }
}

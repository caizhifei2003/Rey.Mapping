namespace Rey.Mapping {
    public class MapNullValue : MapValue {
        public MapNullValue()
            : base(MapValueType.Null) {
        }

        public override object GetValue() {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            return $"[Null]";
        }
    }
}

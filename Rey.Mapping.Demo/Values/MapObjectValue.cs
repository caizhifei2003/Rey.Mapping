namespace Rey.Mapping {
    public class MapObjectValue : MapValue {
        public MapObjectValue()
            : base(MapValueType.Object) {
        }

        public override object GetValue() {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            return $"[Object]";
        }
    }
}

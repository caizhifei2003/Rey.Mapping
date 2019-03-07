namespace Rey.Mapping {
    public class MapNullValue : MapValue {
        public override bool IsNull => true;

        public override object GetValue() {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            return $"[Null]";
        }
    }
}

namespace Rey.Mapping {
    public class MapArrayValue : MapValue {
        public int Length { get; }

        public MapArrayValue(int length)
           : base(MapValueType.Array) {
            this.Length = length;
        }

        public override object GetValue() {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            return $"[Array]:{this.Length}";
        }
    }
}

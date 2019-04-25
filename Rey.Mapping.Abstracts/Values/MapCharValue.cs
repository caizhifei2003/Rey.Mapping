using System;

namespace Rey.Mapping {
    public class MapCharValue : MapValue {
        public Char Value { get; }

        public MapCharValue(Char value)
            : base(MapValueType.Char) {
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

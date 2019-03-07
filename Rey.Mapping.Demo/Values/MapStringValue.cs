using System;

namespace Rey.Mapping {
    public class MapStringValue : MapValue {
        public String Value { get; }

        public MapStringValue(String value)
            : base(MapValueType.String) {
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

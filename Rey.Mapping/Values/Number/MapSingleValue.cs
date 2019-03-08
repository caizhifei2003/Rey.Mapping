using System;

namespace Rey.Mapping {
    public class MapSingleValue : MapNumberValue {
        public Single Value { get; }

        public MapSingleValue(Single value)
            : base(MapValueType.Single) {
            this.Value = value;
        }

        public override object GetValue() {
            return this.Value;
        }

        public override string ToString() {
            return $"{this.Value}";
        }
    }
}

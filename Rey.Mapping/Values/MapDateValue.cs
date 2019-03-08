using System;

namespace Rey.Mapping {
    public class MapDateValue : MapValue {
        public DateTime Value { get; }

        public MapDateValue(DateTime value)
            : base(MapValueType.Date) {
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

using System;

namespace Rey.Mapping {
    public class MapObjectFrom : MapFrom {
        public override MapType Type { get; }
        public override object Value { get; }

        public MapObjectFrom(MapType type, object value) {
            this.Type = type;
            this.Value = value;
        }
    }
}

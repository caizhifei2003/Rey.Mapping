using System;

namespace Rey.Mapping {
    public class MapUInt64Token : MapValueToken<UInt64> {
        public MapUInt64Token(UInt64 value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(UInt64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(UInt64)))
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

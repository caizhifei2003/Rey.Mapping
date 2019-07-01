using System;

namespace Rey.Mapping {
    public class MapUInt32Token : MapValueToken<UInt32> {
        public MapUInt32Token(UInt32 value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(UInt32)) || type.Equals(typeof(UInt64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(UInt32)))
                return this.Value;

            if (type.Equals(typeof(UInt64)))
                return (UInt64)this.Value;

            throw new NotImplementedException();
        }
    }
}

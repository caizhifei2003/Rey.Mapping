using System;

namespace Rey.Mapping {
    public class MapUInt16Token : MapValueToken<UInt16> {
        public MapUInt16Token(UInt16 value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(UInt16)) || type.Equals(typeof(UInt32)) || type.Equals(typeof(UInt64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(UInt16)))
                return this.Value;

            if (type.Equals(typeof(UInt32)))
                return (UInt32)this.Value;

            if (type.Equals(typeof(UInt64)))
                return (UInt64)this.Value;

            throw new NotImplementedException();
        }
    }
}

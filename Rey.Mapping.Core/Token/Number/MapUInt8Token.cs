using System;

namespace Rey.Mapping {
    public class MapUInt8Token : MapNumberToken<Byte> {
        public MapUInt8Token(Byte value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(Byte)) || type.Equals(typeof(UInt16)) || type.Equals(typeof(UInt32)) || type.Equals(typeof(UInt64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(Byte)))
                return this.Value;

            if (type.Equals(typeof(UInt16)))
                return (UInt16)this.Value;

            if (type.Equals(typeof(UInt32)))
                return (UInt32)this.Value;

            if (type.Equals(typeof(UInt64)))
                return (UInt64)this.Value;

            throw new NotImplementedException();
        }
    }
}

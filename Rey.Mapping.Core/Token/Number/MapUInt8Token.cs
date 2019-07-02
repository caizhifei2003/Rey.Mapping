using System;

namespace Rey.Mapping {
    public class MapUInt8Token : MapNumberToken<Byte> {
        public MapUInt8Token(Byte value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<Byte>() || type.Equals<Byte?>()
                || type.Equals<UInt16>() || type.Equals<UInt16?>()
                || type.Equals<UInt32>() || type.Equals<UInt32?>()
                || type.Equals<UInt64>() || type.Equals<UInt64?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<Byte>() || type.Equals<Byte?>())
                return this.Value;

            if (type.Equals<UInt16>() || type.Equals<UInt16?>())
                return (UInt16)this.Value;

            if (type.Equals<UInt32>() || type.Equals<UInt32?>())
                return (UInt32)this.Value;

            if (type.Equals<UInt64>() || type.Equals<UInt64?>())
                return (UInt64)this.Value;

            throw new NotImplementedException();
        }
    }
}

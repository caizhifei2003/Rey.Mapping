using System;

namespace Rey.Mapping {
    public class MapUInt16Token : MapNumberToken<UInt16> {
        public MapUInt16Token(UInt16 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<UInt16>() || type.Equals<UInt16?>()
                || type.Equals<UInt32>() || type.Equals<UInt32?>()
                || type.Equals<UInt64>() || type.Equals<UInt64?>()
                || type.Equals<string>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<UInt16>() || type.Equals<UInt16?>())
                return this.Value;

            if (type.Equals<UInt32>() || type.Equals<UInt32?>())
                return (UInt32)this.Value;

            if (type.Equals<UInt64>() || type.Equals<UInt64?>())
                return (UInt64)this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

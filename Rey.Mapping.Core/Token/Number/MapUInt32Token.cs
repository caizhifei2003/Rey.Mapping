using System;

namespace Rey.Mapping {
    public class MapUInt32Token : MapNumberToken<UInt32> {
        public MapUInt32Token(UInt32 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<UInt32>() || type.Equals<UInt32?>()
                || type.Equals<UInt64>() || type.Equals<UInt64?>()
                || type.Equals<string>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<UInt32>() || type.Equals<UInt32?>())
                return this.Value;

            if (type.Equals<UInt64>() || type.Equals<UInt64?>())
                return (UInt64)this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

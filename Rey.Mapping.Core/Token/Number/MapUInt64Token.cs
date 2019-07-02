using System;

namespace Rey.Mapping {
    public class MapUInt64Token : MapNumberToken<UInt64> {
        public MapUInt64Token(UInt64 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<UInt64>() || type.Equals<UInt64?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<UInt64>() || type.Equals<UInt64?>())
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

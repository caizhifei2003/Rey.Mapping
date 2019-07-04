using System;

namespace Rey.Mapping {
    public class MapUInt64Token : MapNumberToken<UInt64> {
        public MapUInt64Token(UInt64 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<UInt64>() || type.Equals<UInt64?>()
                || type.Equals<string>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<UInt64>() || type.Equals<UInt64?>())
                return this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

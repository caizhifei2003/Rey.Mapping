using System;

namespace Rey.Mapping {
    public class MapInt64Token : MapNumberToken<Int64> {
        public MapInt64Token(Int64 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<Int64>() || type.Equals<Int64?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<Int64>() || type.Equals<Int64?>())
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

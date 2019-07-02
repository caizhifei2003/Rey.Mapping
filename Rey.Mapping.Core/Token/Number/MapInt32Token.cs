using System;

namespace Rey.Mapping {
    public class MapInt32Token : MapNumberToken<Int32> {
        public MapInt32Token(Int32 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<Int32>() || type.Equals<Int32?>()
                || type.Equals<Int64>() || type.Equals<Int64?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<Int32>() || type.Equals<Int32?>())
                return this.Value;

            if (type.Equals<Int64>() || type.Equals<Int64?>())
                return (Int64)this.Value;

            throw new NotImplementedException();
        }
    }
}

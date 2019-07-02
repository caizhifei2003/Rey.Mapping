using System;

namespace Rey.Mapping {
    public class MapInt16Token : MapNumberToken<Int16> {
        public MapInt16Token(Int16 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<Int16>() || type.Equals<Int16?>()
                || type.Equals<Int32>() || type.Equals<Int32?>()
                || type.Equals<Int64>() || type.Equals<Int64?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<Int16>() || type.Equals<Int16?>())
                return this.Value;

            if (type.Equals<Int32>() || type.Equals<Int32?>())
                return (Int32)this.Value;

            if (type.Equals<Int64>() || type.Equals<Int64?>())
                return (Int64)this.Value;

            throw new NotImplementedException();
        }
    }
}

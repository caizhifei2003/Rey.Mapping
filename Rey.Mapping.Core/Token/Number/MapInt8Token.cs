using System;

namespace Rey.Mapping {
    public class MapInt8Token : MapNumberToken<SByte> {
        public MapInt8Token(SByte value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<SByte>() || type.Equals<SByte?>()
                || type.Equals<Int16>() || type.Equals<Int16?>()
                || type.Equals<Int32>() || type.Equals<Int32?>()
                || type.Equals<Int64>() || type.Equals<Int64?>()
                || type.Equals<string>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<SByte>() || type.Equals<SByte?>())
                return this.Value;

            if (type.Equals<Int16>() || type.Equals<Int16?>())
                return (Int16)this.Value;

            if (type.Equals<Int32>() || type.Equals<Int32?>())
                return (Int32)this.Value;

            if (type.Equals<Int64>() || type.Equals<Int64?>())
                return (Int64)this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

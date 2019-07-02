using System;

namespace Rey.Mapping {
    public class MapInt8Token : MapNumberToken<SByte> {
        public MapInt8Token(SByte value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(SByte)) || type.Equals(typeof(Int16)) || type.Equals(typeof(Int32)) || type.Equals(typeof(Int64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(SByte)))
                return this.Value;

            if (type.Equals(typeof(Int16)))
                return (Int16)this.Value;

            if (type.Equals(typeof(Int32)))
                return (Int32)this.Value;

            if (type.Equals(typeof(Int64)))
                return (Int64)this.Value;
            throw new NotImplementedException();
        }
    }
}

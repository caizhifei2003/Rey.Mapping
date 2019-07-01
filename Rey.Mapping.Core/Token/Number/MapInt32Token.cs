using System;

namespace Rey.Mapping {
    public class MapInt32Token : MapValueToken<Int32> {
        public MapInt32Token(Int32 value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(Int32)) || type.Equals(typeof(Int64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(Int32)))
                return this.Value;

            if (type.Equals(typeof(Int64)))
                return (Int64)this.Value;

            throw new NotImplementedException();
        }
    }
}

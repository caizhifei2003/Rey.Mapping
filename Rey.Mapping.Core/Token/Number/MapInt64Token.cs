using System;

namespace Rey.Mapping {
    public class MapInt64Token : MapValueToken<Int64> {
        public MapInt64Token(Int64 value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(Int64));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(Int64)))
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

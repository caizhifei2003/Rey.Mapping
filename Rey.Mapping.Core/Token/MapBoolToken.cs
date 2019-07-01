using System;

namespace Rey.Mapping {
    public class MapBoolToken : MapValueToken<bool> {
        public MapBoolToken(bool value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(bool));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(bool)))
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

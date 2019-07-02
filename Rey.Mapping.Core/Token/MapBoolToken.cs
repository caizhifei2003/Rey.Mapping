using System;

namespace Rey.Mapping {
    public class MapBoolToken : MapValueToken<bool> {
        public MapBoolToken(bool value)
            : base(value, typeof(bool)) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<bool>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<bool>())
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

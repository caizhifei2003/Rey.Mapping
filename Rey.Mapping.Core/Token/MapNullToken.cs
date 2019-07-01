using System;

namespace Rey.Mapping {
    public class MapNullToken : MapValueToken {
        public MapNullToken(Type type)
            : base(type) {
        }

        public override bool Compatible(Type type) {
            return !type.IsValueType;
        }

        public override object GetValue(Type type) {
            if (!type.IsValueType)
                return null;

            throw new NotImplementedException();
        }
    }
}

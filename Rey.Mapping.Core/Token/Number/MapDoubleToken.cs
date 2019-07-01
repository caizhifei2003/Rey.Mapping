using System;

namespace Rey.Mapping {
    public class MapDoubleToken : MapValueToken<Double> {
        public MapDoubleToken(Double value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(Double));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(Double)))
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

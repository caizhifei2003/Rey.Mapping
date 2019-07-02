using System;

namespace Rey.Mapping {
    public class MapSingleToken : MapNumberToken<Single> {
        public MapSingleToken(Single value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<Single>() || type.Equals<Single?>()
                || type.Equals<Double>() || type.Equals<Double?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<Single>() || type.Equals<Single?>())
                return this.Value;

            if (type.Equals<Double>() || type.Equals<Double?>())
                return (Double)this.Value;

            throw new NotImplementedException();
        }
    }
}

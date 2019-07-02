using System;

namespace Rey.Mapping {
    public class MapDoubleToken : MapNumberToken<Double> {
        public MapDoubleToken(Double value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<double>() || type.Equals<double?>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<double>() || type.Equals<double?>())
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

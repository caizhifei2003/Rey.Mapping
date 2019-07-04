using System;

namespace Rey.Mapping {
    public class MapSingleToken : MapNumberToken<Single> {
        public MapSingleToken(Single value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<Single>() || type.Equals<Single?>()
                || type.Equals<Double>() || type.Equals<Double?>()
                || type.Equals<string>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<Single>() || type.Equals<Single?>())
                return this.Value;

            if (type.Equals<Double>() || type.Equals<Double?>())
                return Double.Parse(this.Value.ToString());

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

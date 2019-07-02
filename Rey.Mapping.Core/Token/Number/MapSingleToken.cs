using System;

namespace Rey.Mapping {
    public class MapSingleToken : MapNumberToken<Single> {
        public MapSingleToken(Single value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return type.Equals(typeof(Single)) || type.Equals(typeof(Double));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(Single)))
                return this.Value;

            if (type.Equals(typeof(Double)))
                return (Double)this.Value;

            throw new NotImplementedException();
        }
    }
}

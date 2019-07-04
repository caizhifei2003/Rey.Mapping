using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapSingleToken : MapNumberToken<Single> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(Single), typeof(Double),
        };

        public MapSingleToken(Single value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<Single>())
                return this.Value;

            if (type.Equals<Double>())
                return Double.Parse(this.Value.ToString());

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

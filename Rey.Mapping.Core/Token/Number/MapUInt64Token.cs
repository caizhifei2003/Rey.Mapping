using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapUInt64Token : MapNumberToken<UInt64> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(UInt64),
        };

        public MapUInt64Token(UInt64 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<UInt64>())
                return this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapUInt16Token : MapNumberToken<UInt16> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(UInt16), typeof(UInt32), typeof(UInt64),
        };

        public MapUInt16Token(UInt16 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<UInt16>())
                return this.Value;

            if (type.Equals<UInt32>())
                return (UInt32)this.Value;

            if (type.Equals<UInt64>())
                return (UInt64)this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

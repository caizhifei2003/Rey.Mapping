using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapInt32Token : MapNumberToken<Int32> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(Int32), typeof(Int64),
        };

        public MapInt32Token(Int32 value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<Int32>())
                return this.Value;

            if (type.Equals<Int64>())
                return (Int64)this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

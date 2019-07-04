using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapInt8Token : MapNumberToken<SByte> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(SByte), typeof(Int16), typeof(Int32), typeof(Int64),
        };

        public MapInt8Token(SByte value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<SByte>())
                return this.Value;

            if (type.Equals<Int16>())
                return (Int16)this.Value;

            if (type.Equals<Int32>())
                return (Int32)this.Value;

            if (type.Equals<Int64>())
                return (Int64)this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

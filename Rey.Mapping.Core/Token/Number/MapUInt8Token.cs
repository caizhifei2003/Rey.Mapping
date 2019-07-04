using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapUInt8Token : MapNumberToken<Byte> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(Byte), typeof(UInt16), typeof(UInt32), typeof(UInt64),
        };

        public MapUInt8Token(Byte value)
            : base(value) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<Byte>())
                return this.Value;

            if (type.Equals<UInt16>())
                return (UInt16)this.Value;

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

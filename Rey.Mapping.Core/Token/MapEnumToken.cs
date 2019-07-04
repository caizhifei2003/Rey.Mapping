using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapEnumToken : MapValueToken<object> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string),
            typeof(SByte), typeof(Int16), typeof(Int32), typeof(Int64),
            typeof(Byte), typeof(UInt16), typeof(UInt32), typeof(UInt64)
        };

        public MapEnumToken(object value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            if (type.Equals(this.Type))
                return true;

            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals(this.Type))
                return this.Value;

            if (type.Equals<string>())
                return Enum.GetName(this.Type, this.Value);

            if (type.Equals<SByte>())
                return (SByte)this.Value;

            if (type.Equals<Int16>())
                return (Int16)this.Value;

            if (type.Equals<Int32>())
                return (Int32)this.Value;

            if (type.Equals<Int64>())
                return (Int64)this.Value;

            if (type.Equals<Byte>())
                return (Byte)this.Value;

            if (type.Equals<UInt16>())
                return (UInt16)this.Value;

            if (type.Equals<UInt32>())
                return (UInt32)this.Value;

            if (type.Equals<UInt64>())
                return (UInt64)this.Value;

            throw new NotImplementedException();
        }
    }
}

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
                return Convert.ChangeType(this.Value, typeof(SByte));

            if (type.Equals<Int16>())
                return Convert.ChangeType(this.Value, typeof(Int16));

            if (type.Equals<Int32>())
                return Convert.ChangeType(this.Value, typeof(Int32));

            if (type.Equals<Int64>())
                return Convert.ChangeType(this.Value, typeof(Int64));

            if (type.Equals<Byte>())
                return Convert.ChangeType(this.Value, typeof(Byte));

            if (type.Equals<UInt16>())
                return Convert.ChangeType(this.Value, typeof(UInt16));

            if (type.Equals<UInt32>())
                return Convert.ChangeType(this.Value, typeof(UInt32));

            if (type.Equals<UInt64>())
                return Convert.ChangeType(this.Value, typeof(UInt64));

            throw new NotImplementedException();
        }
    }
}

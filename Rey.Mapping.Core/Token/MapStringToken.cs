using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapStringToken : MapValueToken<string> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(DateTime), typeof(TimeSpan), typeof(Boolean), typeof(Char),
            typeof(SByte), typeof(Int16), typeof(Int32), typeof(Int64),
            typeof(Byte), typeof(UInt16), typeof(UInt32), typeof(UInt64),
            typeof(Single), typeof(Double), typeof(Decimal),
        };

        public MapStringToken(string value)
            : base(value, typeof(string)) {
        }

        public override bool Compatible(Type type) {
            if (type.IsEnum)
                return true;

            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.IsEnum)
                return Enum.Parse(type, this.Value);

            if (type.Equals<string>())
                return this.Value;

            if (type.Equals<DateTime>())
                return DateTime.Parse(this.Value);

            if (type.Equals<TimeSpan>())
                return TimeSpan.Parse(this.Value);

            if (type.Equals<Boolean>())
                return Boolean.Parse(this.Value);

            if (type.Equals<Char>())
                return Char.Parse(this.Value);

            if (type.Equals<SByte>())
                return SByte.Parse(this.Value);

            if (type.Equals<Int16>())
                return Int16.Parse(this.Value);

            if (type.Equals<Int32>())
                return Int32.Parse(this.Value);

            if (type.Equals<Int64>())
                return Int64.Parse(this.Value);

            if (type.Equals<Byte>())
                return Byte.Parse(this.Value);

            if (type.Equals<UInt16>())
                return UInt16.Parse(this.Value);

            if (type.Equals<UInt32>())
                return UInt32.Parse(this.Value);

            if (type.Equals<UInt64>())
                return UInt64.Parse(this.Value);

            if (type.Equals<Single>())
                return Single.Parse(this.Value);

            if (type.Equals<Double>())
                return Double.Parse(this.Value);

            if (type.Equals<Decimal>())
                return Decimal.Parse(this.Value);

            throw new NotImplementedException();
        }
    }
}

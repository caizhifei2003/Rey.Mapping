using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapDateTimeToken : MapValueToken<DateTime> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(DateTime), typeof(string)
        };

        public MapDateTimeToken(DateTime value)
            : base(value, typeof(DateTime)) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<DateTime>())
                return this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

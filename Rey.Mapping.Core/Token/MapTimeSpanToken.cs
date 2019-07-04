using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapTimeSpanToken : MapValueToken<TimeSpan> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(TimeSpan), typeof(string)
        };

        public MapTimeSpanToken(TimeSpan value)
            : base(value, typeof(TimeSpan)) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<TimeSpan>())
                return this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapCharToken : MapValueToken<char> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(char), typeof(string)
        };

        public MapCharToken(char value)
            : base(value, typeof(char)) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<char>())
                return this.Value;

            if (type.Equals<string>())
                return this.Value.ToString();

            throw new NotImplementedException();
        }
    }
}

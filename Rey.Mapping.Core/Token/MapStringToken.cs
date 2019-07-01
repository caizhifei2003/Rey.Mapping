using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapStringToken : MapValueToken<string> {
        public MapStringToken(string value, Type type)
            : base(value, type) {
        }

        public override bool Compatible(Type type) {
            return new List<Type>() { typeof(string), typeof(char), typeof(DateTime), typeof(TimeSpan) }.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals(typeof(char)))
                return char.Parse(this.Value);

            if (type.Equals(typeof(string)))
                return this.Value;

            if (type.Equals(typeof(DateTime)))
                return DateTime.Parse(this.Value);

            if (type.Equals(typeof(TimeSpan)))
                return TimeSpan.Parse(this.Value);

            throw new NotImplementedException();
        }
    }
}

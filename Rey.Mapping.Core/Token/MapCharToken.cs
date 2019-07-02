using System;

namespace Rey.Mapping {
    public class MapCharToken : MapValueToken<char> {
        public MapCharToken(char value)
            : base(value, typeof(char)) {
        }

        public override bool Compatible(Type type) {
            return type.Equals<char>();
        }

        public override object GetValue(Type type) {
            if (type.Equals<char>())
                return this.Value;

            throw new NotImplementedException();
        }
    }
}

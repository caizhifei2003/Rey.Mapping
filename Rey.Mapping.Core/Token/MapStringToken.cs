using System;

namespace Rey.Mapping {
    public class MapStringToken : MapValueToken<string> {
        public MapStringToken(string value, Type type)
            : base(value, type) {
        }
    }
}

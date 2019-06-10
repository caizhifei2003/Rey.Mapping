using System;

namespace Rey.Mapping {
    public class MapStringToken : MapToken<string> {
        public MapStringToken(string fromValue, Type fromType)
            : base(fromValue, fromType) {
        }

        public override string GetStringValue() {
            return this.FromValue;
        }
    }
}

using System;

namespace Rey.Mapping {
    public class MapObjectToken : MapValueToken {
        public MapObjectToken(Type type)
            : base(type) {
        }

        public override bool Compatible(Type type) {
            throw new NotImplementedException();
        }

        public override object GetValue(Type type) {
            throw new NotImplementedException();
        }
    }
}

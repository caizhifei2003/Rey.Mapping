using System;

namespace Rey.Mapping {
    public class MapObjectToken : MapToken {
        public MapObjectToken() {
        }

        public override bool Compatible(Type type) {
            throw new NotImplementedException();
        }

        public override object GetValue(Type type) {
            throw new NotImplementedException();
        }
    }
}

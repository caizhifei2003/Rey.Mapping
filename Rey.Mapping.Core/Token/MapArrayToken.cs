using System;

namespace Rey.Mapping {
    public class MapArrayToken : MapValueToken {
        public Type ElementType { get; }

        public MapArrayToken(Type type, Type elementType) : base(type) {
            this.ElementType = elementType;
        }

        public override bool Compatible(Type type) {
            throw new NotImplementedException();
        }

        public override object GetValue(Type type) {
            throw new NotImplementedException();
        }
    }
}

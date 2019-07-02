using System;

namespace Rey.Mapping {
    public class MapNullableToken : MapValueToken {
        public Type InnerType { get; }

        public MapNullableToken(Type type, Type innerType)
            : base(type) {
            this.InnerType = innerType;
        }

        public override bool Compatible(Type type) {
            throw new NotImplementedException();
        }

        public override object GetValue(Type type) {
            throw new NotImplementedException();
        }
    }
}

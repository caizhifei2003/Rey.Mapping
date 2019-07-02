using System;

namespace Rey.Mapping {
    public class MapNullableToken : MapToken {
        public IMapToken Token { get; }

        public MapNullableToken(IMapToken token) {
            this.Token = token;
        }

        public override bool Compatible(Type type) {
            throw new NotImplementedException();
        }

        public override object GetValue(Type type) {
            throw new NotImplementedException();
        }
    }
}

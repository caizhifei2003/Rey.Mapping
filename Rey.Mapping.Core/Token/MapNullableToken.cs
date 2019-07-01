namespace Rey.Mapping {
    public class MapNullableToken : MapToken {
        public IMapToken Token { get; }

        public MapNullableToken(IMapToken token) {
            this.Token = token;
        }
    }
}

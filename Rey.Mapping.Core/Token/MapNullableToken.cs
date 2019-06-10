namespace Rey.Mapping {
    public class MapNullableToken<TValue> : MapToken {
        public MapToken<TValue> Token { get; }

        public MapNullableToken(MapToken<TValue> token) {
            this.Token = token;
        }
    }
}

namespace Rey.Mapping {
    public class MapNullableToken<TValue> : MapToken {
        public MapValueToken<TValue> Token { get; }

        public MapNullableToken(MapValueToken<TValue> token) {
            this.Token = token;
        }
    }
}

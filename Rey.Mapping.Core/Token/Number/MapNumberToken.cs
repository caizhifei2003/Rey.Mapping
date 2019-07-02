namespace Rey.Mapping {
    public abstract class MapNumberToken<TValue> : MapValueToken<TValue> {
        public override bool IsNumber => true;

        public MapNumberToken(TValue value)
            : base(value, typeof(TValue)) {
        }
    }
}

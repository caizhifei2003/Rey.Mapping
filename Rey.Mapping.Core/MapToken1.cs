using System;

namespace Rey.Mapping {
    public abstract class MapToken<TValue> : MapToken, IMapToken<TValue> {
        public TValue FromValue { get; }
        public Type FromType { get; }

        public MapToken(TValue fromValue, Type fromType) {
            this.FromValue = fromValue;
            this.FromType = fromType;
        }
    }
}

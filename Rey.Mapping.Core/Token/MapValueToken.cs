using System;

namespace Rey.Mapping {
    public abstract class MapValueToken : MapToken, IMapValueToken {
        public Type FromType { get; }

        public MapValueToken(Type fromType) {
            this.FromType = fromType;
        }
    }

    public abstract class MapValueToken<TValue> : MapValueToken, IMapValueToken<TValue> {
        public TValue FromValue { get; }

        public MapValueToken(TValue fromValue, Type fromType)
            : base(fromType) {
            this.FromValue = fromValue;
        }
    }
}

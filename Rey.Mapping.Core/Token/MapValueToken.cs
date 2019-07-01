using System;

namespace Rey.Mapping {
    public abstract class MapValueToken : MapToken, IMapValueToken {
        public Type Type { get; }

        public MapValueToken(Type type) {
            this.Type = type;
        }

        public abstract bool Compatible(Type type);

        public abstract object GetValue(Type type);
    }

    public abstract class MapValueToken<TValue> : MapValueToken, IMapValueToken<TValue> {
        public TValue Value { get; }

        public MapValueToken(TValue value, Type type)
            : base(type) {
            this.Value = value;
        }
    }
}

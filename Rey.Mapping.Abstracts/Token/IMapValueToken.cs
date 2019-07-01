using System;

namespace Rey.Mapping {
    public interface IMapValueToken : IMapToken {
        Type Type { get; }

        bool Compatible(Type type);
        object GetValue(Type type);
    }

    public interface IMapValueToken<TValue> : IMapValueToken {
        TValue Value { get; }
    }
}

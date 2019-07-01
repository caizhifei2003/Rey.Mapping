using System;

namespace Rey.Mapping {
    public interface IMapValueToken : IMapToken {
        Type Type { get; }
    }

    public interface IMapValueToken<TValue> : IMapValueToken {
        TValue Value { get; }
    }
}

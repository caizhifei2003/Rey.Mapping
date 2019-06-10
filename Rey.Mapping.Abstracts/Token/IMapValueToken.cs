using System;

namespace Rey.Mapping {
    public interface IMapValueToken : IMapToken {
        Type FromType { get; }
    }

    public interface IMapValueToken<TValue> : IMapValueToken {
        TValue FromValue { get; }
    }
}

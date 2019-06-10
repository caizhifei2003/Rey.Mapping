using System;

namespace Rey.Mapping {
    public interface IMapToken<TValue> : IMapToken {
        TValue FromValue { get; }
        Type FromType { get; }
    }
}

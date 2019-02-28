using System;

namespace Rey.Mapping {
    public interface IMapTo {
        Type Type { get; }
        object Map();
    }

    public interface IMapTo<T> : IMapTo {
    }
}

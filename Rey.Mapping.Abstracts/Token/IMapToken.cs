using System;

namespace Rey.Mapping {
    public interface IMapToken {
        bool IsNumber { get; }

        bool Compatible(Type type);
        object GetValue(Type type);
    }
}

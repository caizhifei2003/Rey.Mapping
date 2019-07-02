using System;

namespace Rey.Mapping {
    public interface IMapToken {
        bool Compatible(Type type);
        object GetValue(Type type);
    }
}

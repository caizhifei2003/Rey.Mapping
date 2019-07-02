using System;

namespace Rey.Mapping {
    public abstract class MapToken : IMapToken {
        public abstract bool Compatible(Type type);
        public abstract object GetValue(Type type);
    }
}

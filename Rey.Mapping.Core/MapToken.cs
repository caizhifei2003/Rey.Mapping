using System;

namespace Rey.Mapping {
    public abstract class MapToken : IMapToken {
        public virtual string GetStringValue() {
            throw new NotImplementedException();
        }
    }
}

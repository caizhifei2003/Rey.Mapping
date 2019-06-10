using System;

namespace Rey.Mapping {
    public abstract class MapToken : IMapToken {
        public virtual bool IsNull => false;

        public virtual string GetStringValue() {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace Rey.Mapping {
    public interface IMapTokenWrapper {
        object To(Type toType, IMapDeserializeOptions options);
    }
}

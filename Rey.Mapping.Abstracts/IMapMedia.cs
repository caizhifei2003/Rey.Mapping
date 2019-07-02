using System;

namespace Rey.Mapping {
    public interface IMapMedia {
        object To(Type toType, IMapDeserializeOptions options);
    }
}

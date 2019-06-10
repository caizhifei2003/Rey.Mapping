using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapNode {
        IMapToken Token { get; }

        object To(Type toType, IMapDeserializeOptions options);
    }
}

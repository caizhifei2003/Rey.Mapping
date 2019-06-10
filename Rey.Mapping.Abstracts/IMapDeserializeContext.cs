using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapDeserializeContext {
        object Deserialize(IMapNode node, Type toType, IMapDeserializeOptions options);
    }
}

using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapDeserializer {
        object Deserialize(IMapNode node, Type toType, IMapDeserializeOptions options);
    }
}

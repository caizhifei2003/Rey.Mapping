using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapConverter {
        bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options);
        IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context);

        bool CanDeserialize(IMapNode node, Type toType, IMapDeserializeOptions options);
        object Deserialize(IMapNode node, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context);
    }
}

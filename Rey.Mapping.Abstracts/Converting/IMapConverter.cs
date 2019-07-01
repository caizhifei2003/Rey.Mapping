using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapConverter {
        bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options);
        IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context);

        bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options);
        object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context);
    }
}

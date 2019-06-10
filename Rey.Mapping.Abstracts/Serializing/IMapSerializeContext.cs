using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapSerializeContext {
        IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options);
        IMapNode CreateNode(IMapToken token);
    }
}

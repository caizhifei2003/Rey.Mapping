using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapDeserializeContext {
        object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options);
    }
}

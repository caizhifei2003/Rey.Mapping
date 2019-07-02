using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapDeserializer {
        object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context = null);
    }
}

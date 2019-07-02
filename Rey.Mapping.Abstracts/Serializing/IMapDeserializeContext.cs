using System;

namespace Rey.Mapping {
    public interface IMapDeserializeContext {
        MapPath Path { get; }
        object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, string segment = null);
    }
}

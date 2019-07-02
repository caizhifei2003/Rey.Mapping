using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapSerializeContext {
        MapPath Path { get; }
        IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, string segment = null);
    }
}

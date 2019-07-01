using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapSerializeContext {
        IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

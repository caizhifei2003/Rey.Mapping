using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapSerializer {
        IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context = null);
    }
}

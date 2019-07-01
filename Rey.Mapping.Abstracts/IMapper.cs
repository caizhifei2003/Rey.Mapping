using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapper {
        IMapToken From(object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

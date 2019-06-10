using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapper {
        IMapNode From(object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

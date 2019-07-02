using System;

namespace Rey.Mapping {
    public interface IMapper {
        IMapTokenWrapper From(object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

using System;

namespace Rey.Mapping {
    public interface IMapper {
        IMapMedia From(object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

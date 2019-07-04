using System;

namespace Rey.Mapping {
    public interface IMapper {
        IMapMedia From(object fromValue, Type fromType, IMapSerializeOptions options);
        IMapMedia From(object fromValue, Type fromType, Action<IMapSerializeOptions> configure = null);

        IMapMedia<TFrom> From<TFrom>(TFrom fromValue, IMapSerializeOptions<TFrom> options);
        IMapMedia<TFrom> From<TFrom>(TFrom fromValue, Action<IMapSerializeOptions<TFrom>> configure = null);
    }
}

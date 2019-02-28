using System;

namespace Rey.Mapping {
    public interface IMapper {
        IMapperOptions Options { get; }
        IMapFrom From(object value, Type type);
        IMapFrom<T> From<T>(T value);
    }
}

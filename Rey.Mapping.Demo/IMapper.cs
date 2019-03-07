using System;

namespace Rey.Mapping {
    public interface IMapper {
        IAggFromMapper FromMapper { get; }
        IAggToMapper ToMapper { get; }
        IMapToBuilder From(Type type, object value);
        IMapToBuilder From<T>(T value);
    }
}

using System;

namespace Rey.Mapping {
    public interface IMapFromBuilder {
        IMapToBuilder Build();
        IMapFromBuilder Type(Type type);
        IMapFromBuilder Type<T>();
        IMapFromBuilder Value(object value);
    }
}

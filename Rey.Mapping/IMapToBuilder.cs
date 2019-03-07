using System;

namespace Rey.Mapping {
    public interface IMapToBuilder {
        object Build();
        IMapToBuilder Type(Type type);
        IMapToBuilder Type<T>();
        object To(Type type);
        T To<T>();
    }
}

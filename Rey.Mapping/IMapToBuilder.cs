using System;

namespace Rey.Mapping {
    public interface IMapToBuilder {
        object To(Type type);
        object To(Type type, IMapToOptions options);
        object To(Type type, Action<IMapToOptions> build);

        T To<T>();
        T To<T>(IMapToOptions options);
        T To<T>(Action<IMapToOptions> build);
    }
}

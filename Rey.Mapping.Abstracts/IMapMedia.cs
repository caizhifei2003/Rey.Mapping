using System;

namespace Rey.Mapping {
    public interface IMapMedia {
        object To(Type toType, IMapDeserializeOptions options);
    }

    public interface IMapMedia<TFrom> : IMapMedia {
        object To(Type toType, IMapDeserializeOptions<TFrom> options);
        object To(Type toType, Action<IMapDeserializeOptions<TFrom>> configure = null);

        TTo To<TTo>(IMapDeserializeOptions<TFrom, TTo> options);
        TTo To<TTo>(Action<IMapDeserializeOptions<TFrom, TTo>> configure = null);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public interface IMapToOptions {
        List<IToMapper> Mappers { get; }

        IMapToOptions MapTo(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(Type type, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(MapPath path, Func<Type, MapPath, MapToContext, object> func);
    }

    public interface IMapToOptions<T> : IMapToOptions {
        IMapToOptions MapTo(Type type, Expression<Func<T, object>> path, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(Expression<Func<T, object>> path, Func<Type, MapPath, MapToContext, object> func);
    }
}

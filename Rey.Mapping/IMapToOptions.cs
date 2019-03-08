using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public interface IMapToOptions {
        List<IToMapper> Mappers { get; }

        IMapToOptions MapTo(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(Type type, Func<Type, MapPath, MapToContext, object> func);
        IMapToOptions MapTo(MapPath path, Func<Type, MapPath, MapToContext, object> func);
    }
}

using System;

namespace Rey.Mapping.Configuration {
    public interface IMappingBuilder {
        MappingOptions Options { get; set; }

        IMappingBuilder AddFromMapper<T>()
            where T : class, IFromMapper;

        IMappingBuilder AddToMapper<T>()
            where T : class, IToMapper;

        IMappingBuilder AddToMapper(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func);
        IMappingBuilder AddToMapper(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func);
        IMappingBuilder AddToMapper(Type type, Func<Type, MapPath, MapToContext, object> func);
        IMappingBuilder AddToMapper(MapPath path, Func<Type, MapPath, MapToContext, object> func);
    }
}

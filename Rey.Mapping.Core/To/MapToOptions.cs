using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public class MapToOptions : IMapToOptions {
        public List<IToMapper> Mappers { get; } = new List<IToMapper>();

        public IMapToOptions MapTo(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func) {
            this.Mappers.Add(new CustomToMapper(canFunc, func));
            return this;
        }

        public IMapToOptions MapTo(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func) {
            this.Mappers.Add(new CustomToMapper(type, path, func));
            return this;
        }

        public IMapToOptions MapTo(Type type, Func<Type, MapPath, MapToContext, object> func) {
            this.Mappers.Add(new CustomToMapper(type, func));
            return this;
        }

        public IMapToOptions MapTo(MapPath path, Func<Type, MapPath, MapToContext, object> func) {
            this.Mappers.Add(new CustomToMapper(path, func));
            return this;
        }
    }

    public class MapToOptions<T> : MapToOptions, IMapToOptions<T> {
        public IMapToOptions MapTo(Type type, Expression<Func<T, object>> path, Func<Type, MapPath, MapToContext, object> func) {
            return this.MapTo(type, MapPath.Parse(path), func);
        }

        public IMapToOptions MapTo(Expression<Func<T, object>> path, Func<Type, MapPath, MapToContext, object> func) {
            return this.MapTo(MapPath.Parse(path), func);
        }
    }
}

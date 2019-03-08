using System;
using System.Collections.Generic;

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
}

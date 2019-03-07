using System;

namespace Rey.Mapping {
    public class CustomToMapper : IToMapper {
        public Func<Type, MapPath, bool> CanFunc { get; }
        public Func<Type, MapPath, MapToContext, object> Func { get; }

        public bool CanMapTo(Type type, MapPath path) => this.CanFunc(type, path);
        public object MapTo(Type type, MapPath path, MapToContext context) => this.Func(type, path, context);

        public CustomToMapper(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func) {
            this.CanFunc = canFunc;
            this.Func = func;
        }

        public CustomToMapper(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func)
            : this((x1, x2) => x1.Equals(type) && x2.Equals(path), func) {
        }

        public CustomToMapper(Type type, Func<Type, MapPath, MapToContext, object> func)
            : this((x1, _) => x1.Equals(type), func) {
        }

        public CustomToMapper(MapPath path, Func<Type, MapPath, MapToContext, object> func)
            : this((_, x2) => x2.Equals(path), func) {
        }

        public CustomToMapper(Func<Type, MapPath, MapToContext, object> func)
            : this("", func) {
        }
    }
}

using System;

namespace Rey.Mapping {
    public class ToNullableMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return type.IsGenericType && typeof(Nullable<>).Equals(type.GetGenericTypeDefinition());
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var elemType = type.GetGenericArguments()[0];
            return context.MapTo(elemType, path);
        }
    }
}

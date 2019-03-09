using System;

namespace Rey.Mapping {
    public class FromNullableMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return type.IsGenericType && typeof(Nullable<>).Equals(type.GetGenericTypeDefinition());
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (value == null)
                return;

            var propHasValue = type.GetProperty("HasValue");
            var hasValue = (bool)propHasValue.GetValue(value);
            if (!hasValue)
                return;

            var propValue = type.GetProperty("Value");
            var elemValue = propValue.GetValue(value);
            var elemType = type.GetGenericArguments()[0];
            context.MapFrom(elemType, elemValue, path);
        }
    }
}

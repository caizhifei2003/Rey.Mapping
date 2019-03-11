using System;

namespace Rey.Mapping {
    public class ToEnumMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return type.IsEnum;
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value == null || value.IsNull)
                return null;

            return value.GetValue();
        }
    }
}

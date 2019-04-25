using System;

namespace Rey.Mapping {
    public class ToInt8Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(SByte).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value == null)
                return null;

            if (value.ValueType != MapValueType.Int8)
                throw new MapToFailedException($"cannot map to Int8 by {value.ValueType}");

            return value.GetValue();
        }
    }
}

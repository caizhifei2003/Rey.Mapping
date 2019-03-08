using System;

namespace Rey.Mapping {
    public class ToInt64Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Int64).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (!value.IsIntNumber)
                throw new MapToFailedException($"cannot map to Int64 by {value.ValueType}");

            if (value.ValueType == MapValueType.Int64)
                return value.GetValue();

            return Convert.ChangeType(value.GetValue(), typeof(Int64));
        }
    }
}

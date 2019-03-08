using System;

namespace Rey.Mapping {
    public class ToInt32Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Int32).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (!value.IsIntNumber || value.ValueType > MapValueType.Int32)
                throw new MapToFailedException($"cannot map to Int32 by {value.ValueType}");

            if (value.ValueType == MapValueType.Int32)
                return value.GetValue();

            return Convert.ChangeType(value.GetValue(), typeof(Int32));
        }
    }
}

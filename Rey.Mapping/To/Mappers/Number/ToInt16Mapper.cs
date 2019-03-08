using System;

namespace Rey.Mapping {
    public class ToInt16Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Int16).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value == null)
                return null;

            if (!value.IsIntNumber || value.ValueType > MapValueType.Int16)
                throw new MapToFailedException($"cannot map to Int16 by {value.ValueType}");

            if (value.ValueType == MapValueType.Int16)
                return value.GetValue();

            return Convert.ChangeType(value.GetValue(), typeof(Int16));
        }
    }
}

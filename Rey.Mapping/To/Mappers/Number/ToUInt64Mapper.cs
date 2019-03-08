using System;

namespace Rey.Mapping {
    public class ToUInt64Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(UInt64).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (!value.IsUIntNumber)
                throw new MapToFailedException($"cannot map to UInt64 by {value.ValueType}");

            if (value.ValueType == MapValueType.UInt64)
                return value.GetValue();

            return Convert.ChangeType(value.GetValue(), typeof(UInt64));
        }
    }
}

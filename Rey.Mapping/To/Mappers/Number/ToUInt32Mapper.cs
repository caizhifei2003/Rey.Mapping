using System;

namespace Rey.Mapping {
    public class ToUInt32Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(UInt32).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value == null)
                return null;

            if (!value.IsUIntNumber || value.ValueType > MapValueType.UInt32)
                throw new MapToFailedException($"cannot map to UInt32 by {value.ValueType}");

            if (value.ValueType == MapValueType.UInt32)
                return value.GetValue();

            return Convert.ChangeType(value.GetValue(), typeof(UInt32));
        }
    }
}

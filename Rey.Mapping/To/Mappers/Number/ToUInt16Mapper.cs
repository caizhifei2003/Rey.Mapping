using System;

namespace Rey.Mapping {
    public class ToUInt16Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(UInt16).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value == null)
                return null;

            if (!value.IsUIntNumber || value.ValueType > MapValueType.UInt16)
                throw new MapToFailedException($"cannot map to UInt16 by {value.ValueType}");

            if (value.ValueType == MapValueType.UInt16)
                return value.GetValue();

            return Convert.ChangeType(value.GetValue(), typeof(UInt16));
        }
    }
}

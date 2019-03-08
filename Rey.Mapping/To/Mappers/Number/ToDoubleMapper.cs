using System;

namespace Rey.Mapping {
    public class ToDoubleMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Double).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value.ValueType == MapValueType.Double)
                return value.GetValue();

            if (value.ValueType == MapValueType.Single)
                return Convert.ChangeType(value.GetValue(), typeof(Double));

            throw new MapToFailedException($"cannot map to Double by {value.ValueType}");
        }
    }
}

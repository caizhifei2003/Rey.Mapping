using System;

namespace Rey.Mapping {
    public class ToStringMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(string).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value.IsNull)
                return null;

            if (value.IsChar)
                return $"{value.GetValue()}";

            if (value.IsString)
                return value.GetValue();

            if (value.IsNumber)
                return $"{value.GetValue()}";

            throw new NotImplementedException();
        }
    }
}

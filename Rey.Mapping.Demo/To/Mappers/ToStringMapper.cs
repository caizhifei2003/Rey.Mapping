using System;

namespace Rey.Mapping {
    public class ToStringMapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!typeof(string).Equals(type))
                throw new MapToFailedException();

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

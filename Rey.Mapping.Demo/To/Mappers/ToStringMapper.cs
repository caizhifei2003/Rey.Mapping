using System;

namespace Rey.Mapping {
    public class ToStringMapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!typeof(string).Equals(type))
                throw new MapToFailedException();

            return context.Values.GetValue(path)?.GetValue();
        }
    }
}

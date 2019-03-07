using System;

namespace Rey.Mapping {
    public class ToInt32Mapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!typeof(Int32).Equals(type))
                throw new MapToFailedException();

            var value = context.Values.GetValue(path).GetValue();
            return Convert.ChangeType(value, typeof(Int32));
        }
    }
}

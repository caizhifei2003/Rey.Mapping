using System;

namespace Rey.Mapping {
    public class ToInt32Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Int32).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path).GetValue();
            return Convert.ChangeType(value, typeof(Int32));
        }
    }
}

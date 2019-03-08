using System;

namespace Rey.Mapping {
    public class ToInt64Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Int64).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            return context.Values.GetValue(path).GetValue();
        }
    }
}

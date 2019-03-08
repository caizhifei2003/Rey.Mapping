using System;

namespace Rey.Mapping {
    public class ToFloatMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(float).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            return context.Values.GetValue(path).GetValue();
        }
    }
}

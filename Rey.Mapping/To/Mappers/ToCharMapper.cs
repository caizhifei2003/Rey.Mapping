using System;

namespace Rey.Mapping {
    public class ToCharMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Char).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path).GetValue();
            return value;
        }
    }
}

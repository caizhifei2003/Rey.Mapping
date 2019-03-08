using System;

namespace Rey.Mapping {
    public class ToSingleMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(Single).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            return context.Values.GetValue(path).GetValue();
        }
    }
}

using System;

namespace Rey.Mapping {
    public class ToUInt8Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(byte).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            return context.Values.GetValue(path).GetValue();
        }
    }
}

using System;

namespace Rey.Mapping {
    public class ToUInt32Mapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return typeof(UInt32).Equals(type);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            return context.Values.GetValue(path).GetValue();
        }
    }
}

using System;

namespace Rey.Mapping {
    public class FromDoubleMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(double).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapDoubleValue((double)value));
        }
    }
}

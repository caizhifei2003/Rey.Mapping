using System;

namespace Rey.Mapping {
    public class FromInt64Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Int64).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapInt64Value((Int64)value));
        }
    }
}

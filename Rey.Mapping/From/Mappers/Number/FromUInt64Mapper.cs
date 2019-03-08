using System;

namespace Rey.Mapping {
    public class FromUInt64Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(UInt64).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapUInt64Value((UInt64)value));
        }
    }
}

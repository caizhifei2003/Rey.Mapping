using System;

namespace Rey.Mapping {
    public class FromUInt16Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(UInt16).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapUInt16Value((UInt16)value));
        }
    }
}

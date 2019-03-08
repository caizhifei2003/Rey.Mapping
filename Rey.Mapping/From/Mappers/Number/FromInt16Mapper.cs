using System;

namespace Rey.Mapping {
    public class FromInt16Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Int16).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapInt16Value((Int16)value));
        }
    }
}

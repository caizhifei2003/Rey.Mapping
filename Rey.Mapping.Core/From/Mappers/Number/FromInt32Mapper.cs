using System;

namespace Rey.Mapping {
    public class FromInt32Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Int32).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapInt32Value((int)value));
        }
    }
}

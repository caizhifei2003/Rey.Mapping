using System;

namespace Rey.Mapping {
    public class FromSingleMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Single).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapSingleValue((Single)value));
        }
    }
}

using System;

namespace Rey.Mapping {
    public class FromFloatMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(float).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapFloatValue((float)value));
        }
    }
}

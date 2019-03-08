using System;

namespace Rey.Mapping {
    public class FromInt8Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(SByte).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapInt8Value((SByte)value));
        }
    }
}

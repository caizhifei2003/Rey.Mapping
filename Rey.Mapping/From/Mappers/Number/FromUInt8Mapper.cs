using System;

namespace Rey.Mapping {
    public class FromUInt8Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Byte).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapUInt8Value((Byte)value));
        }
    }
}

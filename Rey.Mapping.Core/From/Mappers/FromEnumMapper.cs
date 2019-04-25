using System;

namespace Rey.Mapping {
    public class FromEnumMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return type.IsEnum;
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapEnumValue((int)value));
        }
    }
}

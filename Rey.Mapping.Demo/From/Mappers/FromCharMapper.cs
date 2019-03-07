using System;

namespace Rey.Mapping {
    public class FromCharMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Char).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapCharValue((char)value));
        }
    }
}

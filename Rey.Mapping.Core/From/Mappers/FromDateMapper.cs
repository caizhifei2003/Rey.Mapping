using System;

namespace Rey.Mapping {
    public class FromDateMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(DateTime).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapDateValue((DateTime)value));
        }
    }
}

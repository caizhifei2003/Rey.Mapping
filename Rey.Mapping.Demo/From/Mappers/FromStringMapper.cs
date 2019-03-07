using System;

namespace Rey.Mapping {
    public class FromStringMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(string).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (value == null) {
                context.Values.AddValue(path, new MapNullValue());
                return;
            }

            context.Values.AddValue(path, new MapStringValue($"{value}"));
        }
    }
}

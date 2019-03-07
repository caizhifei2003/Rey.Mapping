using System;

namespace Rey.Mapping {
    public class FromStringMapper : IFromMapper {
        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (!typeof(string).Equals(type))
                throw new MapFromFailedException();

            if (value == null) {
                context.Values.AddValue(path, new MapNullValue());
                return;
            }

            context.Values.AddValue(path, new MapStringValue($"{value}"));
        }
    }
}

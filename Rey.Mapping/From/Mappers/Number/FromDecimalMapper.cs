using System;

namespace Rey.Mapping {
    public class FromDecimalMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(Decimal).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapDecimalValue((Decimal)value));
        }
    }
}

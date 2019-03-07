using System;

namespace Rey.Mapping {
    public class FromCharMapper : IFromMapper {
        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (!typeof(Char).Equals(type))
                throw new MapFromFailedException();

            context.Values.AddValue(path, new MapCharValue((char)value));
        }
    }
}

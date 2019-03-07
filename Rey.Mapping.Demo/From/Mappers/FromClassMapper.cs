using System;
using System.Reflection;

namespace Rey.Mapping {
    public class FromClassMapper : IFromMapper {
        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (!type.IsClass || type.Namespace.Equals("System"))
                throw new MapFromFailedException();

            if (value == null) {
                context.Values.AddValue(path, new MapNullValue());
                return;
            }

            context.Values.AddValue(path, new MapObjectValue());
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props) {
                var propValue = prop.GetValue(value);
                context.Mapper.MapFrom(prop.PropertyType, propValue, path.Join(prop.Name), context);
            }
        }
    }
}

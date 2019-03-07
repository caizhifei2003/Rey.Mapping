using System;
using System.Reflection;

namespace Rey.Mapping {
    public class ToClassMapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!type.IsClass || type.Namespace.Equals("System"))
                throw new MapToFailedException();

            var value = context.Values.GetValue(path);
            if (value.IsNull)
                return null;

            var instance = Activator.CreateInstance(type);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props) {
                var propType = prop.PropertyType;
                var propValue = context.Mapper.MapTo(propType, path.Join(prop.Name), context);
                prop.SetValue(instance, propValue);
            }
            return instance;
        }
    }
}

using System;
using System.Reflection;

namespace Rey.Mapping {
    public class ToClassMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return type.IsClass && !type.Namespace.StartsWith("System") && !type.IsArray;
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (value.IsNull)
                return null;

            var instance = Activator.CreateInstance(type);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props) {
                var propType = prop.PropertyType;
                var propPath = path.Join(prop.Name);
                if (!context.Values.HasValue(propPath))
                    continue;

                var propValue = context.MapTo(propType, propPath);
                prop.SetValue(instance, propValue);
            }
            return instance;
        }
    }
}

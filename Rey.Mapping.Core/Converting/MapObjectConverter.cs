using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    public class MapObjectConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return true;
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            context.Table.AddToken(path, new MapObjectToken(fromType));
            var props = fromType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props) {
                var name = prop.Name;
                var type = prop.PropertyType;
                var subPath = path.Append(name);

                //! ignore member by options;
                if (options.IsIgnore(subPath))
                    continue;

                var value = prop.GetValue(fromValue);
                context.Serialize(subPath, value, type, options);
            }
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            return true;
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var obj = Activator.CreateInstance(toType);
            var children = context.Table.GetChildren(path).ToList();
            foreach (var child in children) {
                //! ignore member by options;
                if (options.IsIgnore(child.Key))
                    continue;

                var name = child.Key.LastSegment();
                var prop = toType.GetProperty(name);
                var type = prop.PropertyType;
                var value = context.Deserialize(child.Key, type, options);
                prop.SetValue(obj, value);
            }

            return obj;
        }
    }
}

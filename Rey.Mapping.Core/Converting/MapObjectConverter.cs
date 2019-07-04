using System;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    public class MapObjectConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return true;
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            context.Table.AddToken(path, new MapObjectToken());
            var props = fromType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props) {
                var name = prop.Name;
                var type = prop.PropertyType;
                var subPath = path.Append(name);

                var value = prop.GetValue(fromValue);
                if (value == null)
                    continue;

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

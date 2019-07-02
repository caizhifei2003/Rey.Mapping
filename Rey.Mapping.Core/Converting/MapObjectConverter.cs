using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rey.Mapping {
    public class MapObjectConverter : IMapConverter {
        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return true;
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return true;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            if (token is MapNullToken)
                return null;

            var ret = Activator.CreateInstance(toType);
            var objToken = token as MapObjectToken;
            foreach (var item in objToken.Tokens) {
                var prop = toType.GetProperty(item.Key);
                var name = prop.Name;
                var path = context.Path.Append(name);

                //! ignore member by options;
                if (options.IsIgnore(path))
                    continue;

                var value = context.Deserialize(item.Value, prop.PropertyType, options, name);
                prop.SetValue(ret, value);
            }

            return ret;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var props = fromType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var tokens = new Dictionary<string, IMapToken>();
            foreach (var prop in props) {
                var name = prop.Name;
                var path = context.Path.Append(name);

                //! ignore member by options;
                if (options.IsIgnore(path))
                    continue;

                var value = prop.GetValue(fromValue);
                var token = context.Serialize(value, prop.PropertyType, options, name);
                tokens.Add(name, token);
            }
            return new MapObjectToken(tokens);
        }
    }
}

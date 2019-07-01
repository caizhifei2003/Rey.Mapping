using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    public class MapStringConverter : IMapConverter {
        private static readonly IEnumerable<Type> TYPES = new List<Type>() {
            typeof(char),
            typeof(string),
            typeof(DateTime),
            typeof(TimeSpan)
        };

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            return TYPES.Any(x => x.Equals(fromType));
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return new MapStringToken($"{fromValue}", fromType);
        }

        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return TYPES.Any(x => x.Equals(toType));
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var stringToken = token as MapStringToken;
            var value = stringToken.FromValue;
            if (typeof(char).Equals(toType))
                return char.Parse(value);

            if (typeof(DateTime).Equals(toType))
                return DateTime.Parse(value);

            if (typeof(TimeSpan).Equals(toType))
                return TimeSpan.Parse(value);

            return value;
        }
    }

    public class MapObjectConverter : IMapConverter {
        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return true;
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return true;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var ret = Activator.CreateInstance(toType);
            if (token.IsNull)
                return null;

            var objToken = token as MapObjectToken;
            foreach (var item in objToken.Tokens) {
                var prop = toType.GetProperty(item.Key);
                var value = context.Deserialize(item.Value, prop.PropertyType, options);
                prop.SetValue(ret, value);
            }

            return ret;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var props = fromType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var tokens = new Dictionary<string, IMapToken>();
            foreach (var prop in props) {
                var value = prop.GetValue(fromValue);
                if (value == null) {
                    tokens.Add(prop.Name, new MapNullToken(prop.PropertyType));
                    continue;
                }

                var token = context.Serialize(value, prop.PropertyType, options);
                tokens.Add(prop.Name, token);
            }
            return new MapObjectToken(tokens);
        }
    }
}

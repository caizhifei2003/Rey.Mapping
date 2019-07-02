using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    public class MapArrayConverter : IMapConverter {
        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return token is MapArrayToken && toType.IsArray;
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return fromType.IsArray;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var tokens = (token as MapArrayToken).Tokens.ToList();
            var elemType = toType.GetElementType();
            var arr = Array.CreateInstance(elemType, tokens.Count);
            var mSet = toType.GetMethod("Set", BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < tokens.Count; ++i) {
                var value = context.Deserialize(tokens[i], elemType, options);
                mSet.Invoke(arr, new object[] { i, value });
            }
            return arr;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var elemType = fromType.GetElementType();
            var length = (int)fromType.GetProperty("Length").GetValue(fromValue);
            var mGet = fromType.GetMethod("Get", BindingFlags.Public | BindingFlags.Instance);
            var tokens = new List<IMapToken>();
            for (var i = 0; i < length; ++i) {
                var elem = mGet.Invoke(fromValue, new object[] { i });
                var token = context.Serialize(elem, elemType, options);
                tokens.Add(token);
            }
            return new MapArrayToken(tokens);
        }
    }
}

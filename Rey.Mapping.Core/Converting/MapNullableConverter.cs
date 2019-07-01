using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class MapNullableConverter : IMapConverter {
        private static bool IsNullable(Type type) {
            return Nullable.GetUnderlyingType(type) != null;
        }

        private static IMapValueToken GetValueToken(IMapToken token) {
            return token is MapNullableToken nullable ? nullable.Token as IMapValueToken : token as IMapValueToken;
        }

        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            if (!(token is MapNullableToken) && !IsNullable(toType))
                return false;

            if (IsNullable(toType)) {
                var innerType = toType.GetGenericArguments()[0];
                return GetValueToken(token).Compatible(innerType);
            } else {
                return GetValueToken(token).Compatible(toType);
            }
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return IsNullable(fromType);
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            if (IsNullable(toType)) {
                var innerType = toType.GetGenericArguments()[0];
                return GetValueToken(token).GetValue(innerType);
            } else {
                return GetValueToken(token).GetValue(toType);
            }
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var innerType = fromType.GetGenericArguments()[0];
            var innerToken = context.Serialize(fromValue, innerType, options);
            return new MapNullableToken(innerToken);
        }
    }
}

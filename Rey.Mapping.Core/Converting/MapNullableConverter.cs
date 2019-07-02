using System;

namespace Rey.Mapping {
    public class MapNullableConverter : IMapConverter {
        private static bool IsNullable(Type type) {
            return Nullable.GetUnderlyingType(type) != null;
        }

        //    private static IMapValueToken GetValueToken(IMapToken token) {
        //        return token is MapNullableToken nullable ? nullable.Token as IMapValueToken : token as IMapValueToken;
        //    }

        //    public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
        //        if (!(token is MapNullableToken) && !IsNullable(toType))
        //            return false;

        //        if (IsNullable(toType)) {
        //            var innerType = toType.GetGenericArguments()[0];
        //            return GetValueToken(token).Compatible(innerType);
        //        } else {
        //            return GetValueToken(token).Compatible(toType);
        //        }
        //    }

        //    public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
        //        return IsNullable(fromType);
        //    }

        //    public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
        //        if (IsNullable(toType)) {
        //            var innerType = toType.GetGenericArguments()[0];
        //            return GetValueToken(token).GetValue(innerType);
        //        } else {
        //            return GetValueToken(token).GetValue(toType);
        //        }
        //    }

        //    public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
        //        var innerType = fromType.GetGenericArguments()[0];
        //        var innerToken = context.Serialize(fromValue, innerType, options);
        //        return new MapNullableToken(innerToken);
        //    }
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return IsNullable(fromType);
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var innerType = fromType.GetGenericArguments()[0];
            context.Table.AddToken(path, new MapNullableToken(fromType, innerType));

            var value = fromType.GetProperty("Value").GetValue(fromValue);
            context.Serialize(path.Append("Inner"), value, innerType, options);
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            if (!(token is MapNullableToken))
                return false;

            return context.Table.GetToken(path.Append("Inner")).Compatible(toType);
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            return context.Deserialize(path.Append("Inner"), toType, options);
        }
    }
}

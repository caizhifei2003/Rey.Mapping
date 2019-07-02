using System;

namespace Rey.Mapping {
    public class MapNullableConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return fromType.IsNullable();
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var innerType = fromType.GetGenericArguments()[0];
            context.Table.AddToken(path, new MapNullableToken(fromType, innerType));

            //! get inner value of nullable
            var value = fromValue;
            if (value != null)
                value = fromType.GetProperty("Value").GetValue(fromValue);

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

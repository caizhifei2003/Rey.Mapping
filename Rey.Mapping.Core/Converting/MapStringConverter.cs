using System;

namespace Rey.Mapping {
    public class MapStringConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return fromType.Equals<string>();
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var token = new MapStringToken($"{fromValue}");
            context.Table.AddToken(path, token);
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            if (!(token is MapStringToken))
                return false;

            return token.Compatible(toType);
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            return token.GetValue(toType);
        }
    }
}

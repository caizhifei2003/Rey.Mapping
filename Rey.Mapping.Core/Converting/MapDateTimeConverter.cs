using System;

namespace Rey.Mapping {
    public class MapDateTimeConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return fromType.Equals<DateTime>();
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            context.Table.AddToken(path, new MapDateTimeToken((DateTime)fromValue));
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            if (!(token is MapDateTimeToken))
                return false;

            return token.Compatible(toType);
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            return context.Table.GetToken(path).GetValue(toType);
        }
    }
}

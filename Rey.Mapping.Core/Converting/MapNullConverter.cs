using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class MapNullConverter : IMapConverter {
        public bool CanDeserialize(IMapNode node, Type toType, IMapDeserializeOptions options) {
            return !toType.IsValueType && node.Token.IsNull;
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return !fromType.IsValueType && fromValue == null;
        }

        public object Deserialize(IMapNode node, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            return null;
        }

        public IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return context.CreateNode(new MapNullToken(fromType));
        }
    }
}

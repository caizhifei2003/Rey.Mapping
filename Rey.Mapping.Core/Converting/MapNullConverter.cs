using System;

namespace Rey.Mapping {
    public class MapNullConverter : IMapConverter {
        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return !toType.IsValueType && token is MapNullToken;
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return fromValue == null;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            return null;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return new MapNullToken(fromType);
        }
    }
}

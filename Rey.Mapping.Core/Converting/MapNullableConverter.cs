using System;

namespace Rey.Mapping {
    public class MapNullableConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return fromType.IsNullable();
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var innerType = fromType.GetGenericArguments()[0];
            var innerValue = fromType.GetProperty("Value").GetValue(fromValue);
            context.Serialize(path, innerValue, innerType, options);
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            return toType.IsNullable();
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var innerType = toType.GetGenericArguments()[0];
            return context.Deserialize(path, innerType, options);
        }
    }
}

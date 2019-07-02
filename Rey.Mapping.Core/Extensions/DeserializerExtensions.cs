using System;

namespace Rey.Mapping {
    public static class DeserializerExtensions {
        public static object Deserialize(this IMapDeserializer deserializer, IMapToken token, Type toType, Action<MapDeserializeOptions> configure = null) {
            var options = new MapDeserializeOptions();
            configure?.Invoke(options);
            return deserializer.Deserialize(token, toType, options);
        }

        public static T Deserialize<T>(this IMapDeserializer deserializer, IMapToken token, IMapDeserializeOptions options) {
            return (T)deserializer.Deserialize(token, typeof(T), options);
        }

        public static T Deserialize<T>(this IMapDeserializer deserializer, IMapToken token, Action<MapDeserializeOptions> configure = null) {
            return (T)deserializer.Deserialize(token, typeof(T), configure);
        }
    }
}

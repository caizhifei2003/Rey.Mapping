using System;

namespace Rey.Mapping {
    public static class SerializerExtensions {
        public static IMapToken Serialize(this IMapSerializer serializer, object fromValue, Type fromType, Action<MapSerializeOptions> configure = null) {
            var options = new MapSerializeOptions();
            configure?.Invoke(options);
            return serializer.Serialize(fromValue, fromType, options);
        }

        public static IMapToken Serialize<T>(this IMapSerializer serializer, T fromValue, IMapSerializeOptions options) {
            return serializer.Serialize(fromValue, typeof(T), options);
        }

        public static IMapToken Serialize<T>(this IMapSerializer serializer, T fromValue, Action<MapSerializeOptions> configure = null) {
            return serializer.Serialize(fromValue, typeof(T), configure);
        }
    }
}

using System;

namespace Rey.Mapping {
    public static class MapTokenWrapperExtensions {
        public static object To(this IMapTokenWrapper wrapper, Type toType, Action<MapDeserializeOptions> configure = null) {
            var options = new MapDeserializeOptions();
            configure?.Invoke(options);
            return wrapper.To(toType, options);
        }

        public static T To<T>(this IMapTokenWrapper wrapper, IMapDeserializeOptions options) {
            return (T)wrapper.To(typeof(T), options);
        }

        public static T To<T>(this IMapTokenWrapper wrapper, Action<MapDeserializeOptions> configure = null) {
            return (T)wrapper.To(typeof(T), configure);
        }
    }
}

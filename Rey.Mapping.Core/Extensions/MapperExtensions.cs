using System;

namespace Rey.Mapping {
    public static class MapperExtensions {
        public static IMapMedia From<T>(this IMapper mapper, object fromValue, Type fromType, Action<MapSerializeOptions<T>> configure = null) {
            var options = new MapSerializeOptions<T>();
            configure?.Invoke(options);
            return mapper.From(fromValue, fromType, options);
        }

        public static IMapMedia From<T>(this IMapper mapper, T fromValue, IMapSerializeOptions<T> options) {
            return mapper.From(fromValue, typeof(T), options);
        }

        public static IMapMedia From<T>(this IMapper mapper, T fromValue, Action<IMapSerializeOptions<T>> configure = null) {
            return mapper.From(fromValue, typeof(T), configure);
        }
    }
}

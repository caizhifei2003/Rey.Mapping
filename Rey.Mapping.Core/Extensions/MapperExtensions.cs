using System;

namespace Rey.Mapping {
    public static class MapperExtensions {
        public static IMapMedia From(this IMapper mapper, object fromValue, Type fromType, Action<MapSerializeOptions> configure = null) {
            var options = new MapSerializeOptions();
            configure?.Invoke(options);
            return mapper.From(fromValue, fromType, options);
        }

        public static IMapMedia From<T>(this IMapper mapper, T fromValue, IMapSerializeOptions options) {
            return mapper.From(fromValue, typeof(T), options);
        }

        public static IMapMedia From<T>(this IMapper mapper, T fromValue, Action<MapSerializeOptions> configure = null) {
            return mapper.From(fromValue, typeof(T), configure);
        }
    }
}

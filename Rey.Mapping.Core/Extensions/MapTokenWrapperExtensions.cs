﻿using System;

namespace Rey.Mapping {
    public static class MapTokenWrapperExtensions {
        public static object To(this IMapMedia wrapper, Type toType, Action<MapDeserializeOptions> configure = null) {
            var options = new MapDeserializeOptions();
            configure?.Invoke(options);
            return wrapper.To(toType, options);
        }

        public static T To<T>(this IMapMedia wrapper, IMapDeserializeOptions options) {
            return (T)wrapper.To(typeof(T), options);
        }

        public static T To<T>(this IMapMedia wrapper, Action<IMapDeserializeOptions> configure = null) {
            return (T)wrapper.To(typeof(T), configure);
        }
    }
}

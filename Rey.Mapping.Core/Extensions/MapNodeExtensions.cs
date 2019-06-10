using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public static class MapNodeExtensions {
        public static object To(this IMapNode node, Type toType, Action<MapDeserializeOptions> configure = null) {
            var options = new MapDeserializeOptions();
            configure?.Invoke(options);
            return node.To(toType, options);
        }

        public static T To<T>(this IMapNode node, IMapDeserializeOptions options) {
            return (T)node.To(typeof(T), options);
        }

        public static T To<T>(this IMapNode node, Action<MapDeserializeOptions> configure = null) {
            return (T)node.To(typeof(T), configure);
        }
    }
}

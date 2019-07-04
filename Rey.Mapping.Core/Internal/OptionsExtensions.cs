using System;

namespace Rey.Mapping {
    internal static class OptionsExtensions {
        public static TOptions Configure<TOptions>(this TOptions options, Action<TOptions> configure = null) {
            configure?.Invoke(options);
            return options;
        }

        public static MapperOptions Configure(this MapperOptions options, Action<MapperOptions> configure = null) => Configure<MapperOptions>(options, configure);
    }
}

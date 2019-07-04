using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping {
    public static class OptionsExtensions {
        private static TOptions Configure<TOptions>(this TOptions options, Action<TOptions> configure = null) {
            configure?.Invoke(options);
            return options;
        }

        public static MapperOptions Configure(this MapperOptions options, Action<MapperOptions> configure = null) => Configure<MapperOptions>(options, configure);
    }
}

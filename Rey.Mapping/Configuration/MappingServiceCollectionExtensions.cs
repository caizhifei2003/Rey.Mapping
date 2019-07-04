using Rey.Mapping;
using System;

namespace Microsoft.Extensions.DependencyInjection {
    public static class MappingServiceCollectionExtensions {
        public static IMapperBuilder AddMapping(this IServiceCollection services, IMapperOptions options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var builder = new MapperBuilder(options);
            services.AddSingleton<IMapper>(p => builder.Build());
            return builder;
        }

        public static IMapperBuilder AddMapping(this IServiceCollection services, Action<MapperOptions> configure = null) {
            var options = new MapperOptions();
            configure?.Invoke(options);
            return AddMapping(services, options);
        }
    }
}

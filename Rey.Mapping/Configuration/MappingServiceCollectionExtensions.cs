using Rey.Mapping;
using Rey.Mapping.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection {
    public static class MappingServiceCollectionExtensions {
        public static IServiceCollection AddReyMapping(this IServiceCollection services, Action<IMappingBuilder> configure = null, MappingOptions options = null) {
            var builder = new MappingBuilder(services, options);
            configure?.Invoke(builder);
            services.AddSingleton<IMapper>(builder.Build());
            return services;
        }
    }
}

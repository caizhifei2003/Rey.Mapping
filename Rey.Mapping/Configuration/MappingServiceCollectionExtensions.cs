using Rey.Mapping.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection {
    public static class MappingServiceCollectionExtensions {
        public static IServiceCollection AddReyMapping(this IServiceCollection services, Action<IMappingBuilder> configure = null) {
            var builder = new MappingBuilder(services);
            configure?.Invoke(builder);
            builder.AddDefault();
            return services;
        }
    }
}

﻿using Rey.Mapping;
using Rey.Mapping.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection {
    public static class MappingServiceCollectionExtensions {
        public static IServiceCollection AddMapping(this IServiceCollection services, IMapperOptions options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            services.AddSingleton(options);
            services.AddSingleton<IMapper, Mapper>();
            services.AddSingleton<IMapSerializer, MapSerializer>();
            services.AddSingleton<IMapDeserializer, MapDeserializer>();
            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services, Action<MapperOptions> configure = null) {
            var options = new MapperOptions();
            configure?.Invoke(options);
            return AddMapping(services, options);
        }
    }
}

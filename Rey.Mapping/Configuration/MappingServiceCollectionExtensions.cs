using Rey.Mapping;
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

            services.AddSingleton<IMapSerializeConverter, MapStringConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapStringConverter>();

            //services.AddSingleton<IMapConverter, MapNullConverter>();
            //services.AddSingleton<IMapConverter, MapNumberConverter>();
            //services.AddSingleton<IMapConverter, MapStringConverter>();
            //services.AddSingleton<IMapConverter, MapNullableConverter>();
            //services.AddSingleton<IMapConverter, MapArrayConverter>();
            //services.AddSingleton<IMapConverter, MapObjectConverter>();

            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services, Action<MapperOptions> configure = null) {
            var options = new MapperOptions();
            configure?.Invoke(options);
            return AddMapping(services, options);
        }
    }
}

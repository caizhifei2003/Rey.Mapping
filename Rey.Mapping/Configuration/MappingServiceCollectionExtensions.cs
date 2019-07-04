﻿using Rey.Mapping;
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

            services.AddSingleton<IMapSerializeConverter, MapNullConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapNullConverter>();

            services.AddSingleton<IMapSerializeConverter, MapStringConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapStringConverter>();

            services.AddSingleton<IMapSerializeConverter, MapNumberConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapNumberConverter>();

            services.AddSingleton<IMapSerializeConverter, MapDateTimeConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapDateTimeConverter>();

            services.AddSingleton<IMapSerializeConverter, MapTimeSpanConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapTimeSpanConverter>();

            services.AddSingleton<IMapSerializeConverter, MapEnumConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapEnumConverter>();

            services.AddSingleton<IMapSerializeConverter, MapNullableConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapNullableConverter>();

            services.AddSingleton<IMapSerializeConverter, MapArrayConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapArrayConverter>();

            services.AddSingleton<IMapSerializeConverter, MapObjectConverter>();
            services.AddSingleton<IMapDeserializeConverter, MapObjectConverter>();

            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services, Action<MapperOptions> configure = null) {
            var options = new MapperOptions();
            configure?.Invoke(options);
            return AddMapping(services, options);
        }
    }
}

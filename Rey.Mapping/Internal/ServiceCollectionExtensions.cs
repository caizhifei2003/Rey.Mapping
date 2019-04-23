using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Rey.Mapping {
    internal static class ServiceCollectionExtensions {
        public static IServiceCollection Clone(this IServiceCollection services) {
            IServiceCollection clone = new ServiceCollection();
            foreach (var service in services) {
                clone.Add(service);
            }
            return clone;
        }

        public static IServiceCollection AddFromMapper<T>(this IServiceCollection services)
            where T : class, IFromMapper {
            return services.AddSingleton<IFromMapper, T>();
        }

        public static IServiceCollection AddToMapper<T>(this IServiceCollection services)
            where T : class, IToMapper {
            return services.AddSingleton<IToMapper, T>();
        }

        public static IServiceCollection AddDefaultFromMappers(this IServiceCollection services) {
            services.TryAddSingleton<IAggFromMapper, AggFromMapper>();
            return services
                .AddFromMapper<FromCharMapper>()
                .AddFromMapper<FromStringMapper>()
                .AddFromMapper<FromDateMapper>()
                .AddFromMapper<FromEnumMapper>()
                .AddFromMapper<FromInt8Mapper>()
                .AddFromMapper<FromInt16Mapper>()
                .AddFromMapper<FromInt32Mapper>()
                .AddFromMapper<FromInt64Mapper>()
                .AddFromMapper<FromUInt8Mapper>()
                .AddFromMapper<FromUInt16Mapper>()
                .AddFromMapper<FromUInt32Mapper>()
                .AddFromMapper<FromUInt64Mapper>()
                .AddFromMapper<FromSingleMapper>()
                .AddFromMapper<FromDoubleMapper>()
                .AddFromMapper<FromDecimalMapper>()
                .AddFromMapper<FromNullableMapper>()
                .AddFromMapper<FromArrayMapper>()
                .AddFromMapper<FromEnumerableMapper>()
                .AddFromMapper<FromClassMapper>()
                ;
        }

        public static IServiceCollection AddDefaultToMappers(this IServiceCollection services) {
            services.TryAddSingleton<IAggToMapper, AggToMapper>();
            return services
                .AddToMapper<ToCharMapper>()
                .AddToMapper<ToStringMapper>()
                .AddToMapper<ToDateMapper>()
                .AddToMapper<ToEnumMapper>()
                .AddToMapper<ToInt8Mapper>()
                .AddToMapper<ToInt16Mapper>()
                .AddToMapper<ToInt32Mapper>()
                .AddToMapper<ToInt64Mapper>()
                .AddToMapper<ToUInt8Mapper>()
                .AddToMapper<ToUInt16Mapper>()
                .AddToMapper<ToUInt32Mapper>()
                .AddToMapper<ToUInt64Mapper>()
                .AddToMapper<ToSingleMapper>()
                .AddToMapper<ToDoubleMapper>()
                .AddToMapper<ToDecimalMapper>()
                .AddToMapper<ToNullableMapper>()
                .AddToMapper<ToArrayMapper>()
                .AddToMapper<ToEnumerableMapper>()
                .AddToMapper<ToClassMapper>()
                ;
        }

        public static IServiceCollection AddDefaultMapper(this IServiceCollection services) {
            services.TryAddSingleton<IMapper, Mapper>();
            return services;
        }

        public static IServiceCollection AddMappingDefaults(this IServiceCollection services) {
            return services
                .AddDefaultFromMappers()
                .AddDefaultToMappers()
                .AddDefaultMapper();
        }
    }
}

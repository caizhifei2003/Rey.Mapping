using Microsoft.Extensions.DependencyInjection;
using System;

namespace Rey.Mapping.Configuration {
    public class MappingBuilder : IMappingBuilder {
        public IServiceCollection Services { get; }
        public MappingOptions Options { get; set; }

        public MappingBuilder(IServiceCollection services = null, MappingOptions options = null) {
            this.Services = services ?? new ServiceCollection();
            this.Options = options ?? new MappingOptions();
        }

        public IMappingBuilder AddFromMapper<T>()
            where T : class, IFromMapper {
            this.Services.AddSingleton<IFromMapper, T>();
            return this;
        }

        public MappingBuilder AddDefaultFromMappers() {
            this.Services.AddSingleton<IAggFromMapper, AggFromMapper>();
            this
                .AddFromMapper<FromClassMapper>()
                .AddFromMapper<FromArrayMapper>()
                .AddFromMapper<FromEnumerableMapper>()
                .AddFromMapper<FromCharMapper>()
                .AddFromMapper<FromStringMapper>()
                .AddFromMapper<FromInt32Mapper>();
            return this;
        }

        public IMappingBuilder AddToMapper<T>()
            where T : class, IToMapper {
            this.Services.AddSingleton<IToMapper, T>();
            return this;
        }

        public IMappingBuilder AddToMapper(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func) {
            this.Services.AddSingleton<IToMapper>(new CustomToMapper(canFunc, func));
            return this;
        }

        public IMappingBuilder AddToMapper(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func) {
            this.Services.AddSingleton<IToMapper>(new CustomToMapper(type, path, func));
            return this;
        }

        public IMappingBuilder AddToMapper(Type type, Func<Type, MapPath, MapToContext, object> func) {
            this.Services.AddSingleton<IToMapper>(new CustomToMapper(type, func));
            return this;
        }

        public IMappingBuilder AddToMapper(MapPath path, Func<Type, MapPath, MapToContext, object> func) {
            this.Services.AddSingleton<IToMapper>(new CustomToMapper(path, func));
            return this;
        }

        public MappingBuilder AddDefaultToMappers() {
            this.Services.AddSingleton<IAggToMapper, AggToMapper>();
            this
                .AddToMapper<ToClassMapper>()
                .AddToMapper<ToArrayMapper>()
                .AddToMapper<ToEnumerableMapper>()
                .AddToMapper<ToStringMapper>()
                .AddToMapper<ToInt32Mapper>();
            return this;
        }

        public MappingBuilder AddDefaultMapper() {
            this.Services.AddSingleton(this.Options);
            this.Services.AddSingleton<IMapper, Mapper>();
            return this;
        }

        public MappingBuilder AddDefault() {
            return this
                .AddDefaultFromMappers()
                .AddDefaultToMappers()
                .AddDefaultMapper();
        }
    }
}

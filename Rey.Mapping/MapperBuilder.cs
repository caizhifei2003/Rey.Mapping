using Microsoft.Extensions.DependencyInjection;

namespace Rey.Mapping {
    public class MapperBuilder : IMapperBuilder {
        private IServiceCollection Services { get; } = new ServiceCollection();
        private MapperOptions Options { get; }

        public MapperBuilder(MapperOptions options = null) {
            this.Options = options ?? new MapperOptions();
        }

        public IMapper Build() {
            this.Services.AddSingleton<IMapperOptions>(this.Options);
            this.Services.AddSingleton<IMapper, Mapper>();
            return this.Services.BuildServiceProvider().GetService<IMapper>();
        }

        public IMapperBuilder FromMapper<TFromMapper>()
            where TFromMapper : class, IFromMapper {
            this.Services.AddSingleton<IFromMapper, TFromMapper>();
            return this;
        }

        public IMapperBuilder ToMapper<TToMapper>()
            where TToMapper : class, IToMapper {
            this.Services.AddSingleton<IToMapper, TToMapper>();
            return this;
        }
    }
}

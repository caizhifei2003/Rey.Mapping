using System;

namespace Rey.Mapping {
    public class Mapper : IMapper {
        public IServiceProvider Provider { get; }
        public IMapperOptions Options { get; }

        public Mapper(
            IServiceProvider provider,
            IMapperOptions options) {
            this.Provider = provider;
            this.Options = options;
        }

        public IMapFrom From(object value, Type type) {
            return new MapFrom(this.Provider, value, type);
        }

        public IMapFrom<T> From<T>(T value) {
            return new MapFrom<T>(this.Provider, value);
        }
    }
}

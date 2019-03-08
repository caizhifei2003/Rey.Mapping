using System;

namespace Rey.Mapping {
    public class MapToBuilder : IMapToBuilder {
        public IMapper Mapper { get; }
        public MapValueTable Values { get; }

        public MapToBuilder(IMapper mapper, MapValueTable values) {
            this.Mapper = mapper;
            this.Values = values;
        }

        public object To(Type type) {
            if (type == null)
                throw new InvalidOperationException(nameof(type));

            return this.To(type, new MapToOptions());
        }

        public object To(Type type, IMapToOptions options) {
            if (type == null)
                throw new InvalidOperationException(nameof(type));

            if (options == null)
                throw new InvalidOperationException(nameof(options));

            var context = new MapToContext(options, this.Mapper.ToMapper, this.Values);
            return context.MapTo(type, new MapPath());
        }

        public object To(Type type, Action<IMapToOptions> build) {
            if (type == null)
                throw new InvalidOperationException(nameof(type));

            if (build == null)
                throw new InvalidOperationException(nameof(build));

            var options = new MapToOptions();
            build.Invoke(options);
            return this.To(type, options);
        }

        public T To<T>() {
            return (T)this.To(typeof(T));
        }

        public T To<T>(IMapToOptions options) {
            if (options == null)
                throw new InvalidOperationException(nameof(options));

            return (T)this.To(typeof(T), options);
        }

        public T To<T>(Action<IMapToOptions> build) {
            if (build == null)
                throw new InvalidOperationException(nameof(build));

            return (T)this.To(typeof(T), build);
        }
    }
}

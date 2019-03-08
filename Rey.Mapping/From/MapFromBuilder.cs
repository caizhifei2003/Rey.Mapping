using System;

namespace Rey.Mapping {
    public class MapFromBuilder : IMapFromBuilder {
        public IMapper Mapper { get; }
        public Type FromType { get; private set; }
        public object FromValue { get; private set; }

        public MapFromBuilder(IMapper mapper) {
            this.Mapper = mapper;
        }

        public IMapToBuilder Build() {
            var context = new MapFromContext(this.Mapper.FromMapper);
            var path = new MapPath();
            this.Mapper.FromMapper.MapFrom(this.FromType, this.FromValue, path, context);
            return new MapToBuilder(this.Mapper, context.Values);
        }

        public IMapFromBuilder Type(Type type) {
            this.FromType = type;
            return this;
        }

        public IMapFromBuilder Type<T>() {
            return this.Type(typeof(T));
        }

        public IMapFromBuilder Value(object value) {
            this.FromValue = value;
            return this;
        }
    }
}

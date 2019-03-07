using System;

namespace Rey.Mapping {
    public class MapToBuilder : IMapToBuilder {
        public IMapper Mapper { get; }
        public MapValueTable Values { get; }
        public Type ToType { get; private set; }

        public MapToBuilder(IMapper mapper, MapValueTable values) {
            this.Mapper = mapper;
            this.Values = values;
        }

        public object Build() {
            var context = new MapToContext(this.Mapper.ToMapper, this.Values);
            var path = new MapPath();
            return this.Mapper.ToMapper.MapTo(this.ToType, path, context);
        }

        public IMapToBuilder Type(Type type) {
            this.ToType = type;
            return this;
        }

        public IMapToBuilder Type<T>() {
            return this.Type(typeof(T));
        }

        public object To(Type type) {
            return this.Type(type).Build();
        }

        public object To<T>() {
            return this.Type<T>().Build();
        }
    }
}

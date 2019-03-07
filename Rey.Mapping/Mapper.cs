using System;

namespace Rey.Mapping {
    public class Mapper : IMapper {
        public IAggFromMapper FromMapper { get; }
        public IAggToMapper ToMapper { get; }

        public Mapper(IAggFromMapper fromMapper, IAggToMapper toMapper) {
            this.FromMapper = fromMapper;
            this.ToMapper = toMapper;
        }

        public IMapToBuilder From(Type type, object value) {
            return new MapFromBuilder(this).Type(type).Value(value).Build();
        }

        public IMapToBuilder From<T>(T value) {
            return new MapFromBuilder(this).Type<T>().Value(value).Build();
        }
    }
}

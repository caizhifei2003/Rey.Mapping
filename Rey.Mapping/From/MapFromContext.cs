using System;

namespace Rey.Mapping {
    public class MapFromContext {
        private IAggFromMapper Mapper { get; }
        public MapValueTable Values { get; } = new MapValueTable();

        public MapFromContext(IAggFromMapper mapper) {
            this.Mapper = mapper;
        }

        public void MapFrom(Type type, object value, MapPath path) {
            this.Mapper.MapFrom(type, value, path, this);
        }
    }
}

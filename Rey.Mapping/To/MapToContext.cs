using System;
using System.Linq;

namespace Rey.Mapping {
    public class MapToContext {
        public IMapToOptions Options { get; }
        private IAggToMapper Mapper { get; }
        public MapValueTable Values { get; }

        public MapToContext(IMapToOptions options, IAggToMapper mapper, MapValueTable values) {
            this.Options = options;
            this.Mapper = mapper;
            this.Values = values;
        }

        public object MapTo(Type type, MapPath path) {
            var mapper = this.Options.Mappers.FirstOrDefault(x => x.CanMapTo(type, path));
            if (mapper != null) {
                return mapper.MapTo(type, path, this);
            }

            return this.Mapper.MapTo(type, path, this);
        }
    }
}

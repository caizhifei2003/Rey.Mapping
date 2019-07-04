using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapperBuilder : IMapperBuilder {
        private readonly IMapperOptions _options;
        private readonly List<Func<IMapSerializeConverter>> _serializeConverters = new List<Func<IMapSerializeConverter>>();
        private readonly List<Func<IMapDeserializeConverter>> _deserializeConverters = new List<Func<IMapDeserializeConverter>>();

        public MapperBuilder(Action<MapperOptions> configure = null)
            : this(new MapperOptions().Configure(configure)) {

        }

        public MapperBuilder(IMapperOptions options) {
            this._options = options;
        }

        public IMapperBuilder AddSerializeConverter(Func<IMapSerializeConverter> converter, int order = 0) {
            throw new NotImplementedException();
        }

        public IMapperBuilder AddSerializeConverter(IMapSerializeConverter converter, int order = 0) {
            throw new NotImplementedException();
        }

        public IMapperBuilder AddDeserializeConverter(Func<IMapDeserializeConverter> converter, int order = 0) {
            throw new NotImplementedException();
        }

        public IMapperBuilder AddDeserializeConverter(IMapDeserializeConverter converter, int order = 0) {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapperBuilder : IMapperBuilder {
        private readonly IMapperOptions _options;
        private readonly IEnumerable<IMapSerializeConverter> DEFAULTS_SERIALIZE_CONVERTERS = new List<IMapSerializeConverter>() {
            new MapNullConverter(),
            new MapStringConverter(),
            new MapNumberConverter(),
            new MapDateTimeConverter(),
            new MapTimeSpanConverter(),
            new MapEnumConverter(),
            new MapNullableConverter(),
            new MapArrayConverter(),
            new MapObjectConverter(),
        };

        private readonly IEnumerable<IMapDeserializeConverter> DEFAULTS_DESERIALIZE_CONVERTERS = new List<IMapDeserializeConverter>() {
            new MapNullConverter(),
            new MapStringConverter(),
            new MapNumberConverter(),
            new MapDateTimeConverter(),
            new MapTimeSpanConverter(),
            new MapEnumConverter(),
            new MapNullableConverter(),
            new MapArrayConverter(),
            new MapObjectConverter(),
        };

        private readonly List<(Func<IMapSerializeConverter> func, int order)> _serializeConverters = new List<(Func<IMapSerializeConverter> func, int order)>();
        private readonly List<(Func<IMapDeserializeConverter> func, int order)> _deserializeConverters = new List<(Func<IMapDeserializeConverter> func, int order)>();

        public MapperBuilder(Action<MapperOptions> configure = null)
            : this(new MapperOptions().Configure(configure)) {
        }

        public MapperBuilder(IMapperOptions options) {
            this._options = options;
        }

        public IMapperBuilder AddSerializeConverter(Func<IMapSerializeConverter> converter, int order = 0) {
            this._serializeConverters.Add((converter, order));
            return this;
        }

        public IMapperBuilder AddSerializeConverter(IMapSerializeConverter converter, int order = 0) {
            return this.AddSerializeConverter(() => converter, order);
        }

        public IMapperBuilder AddDeserializeConverter(Func<IMapDeserializeConverter> converter, int order = 0) {
            this._deserializeConverters.Add((converter, order));
            return this;
        }

        public IMapperBuilder AddDeserializeConverter(IMapDeserializeConverter converter, int order = 0) {
            return this.AddDeserializeConverter(() => converter, order);
        }

        private IMapSerializer BuildSerializer() {
            var converters = this._serializeConverters.OrderBy(x => x.order).Select(x => x.func()).Union(DEFAULTS_SERIALIZE_CONVERTERS);
            return new MapSerializer(converters);
        }

        private IMapDeserializer BuildDeserializer() {
            var converters = this._deserializeConverters.OrderBy(x => x.order).Select(x => x.func()).Union(DEFAULTS_DESERIALIZE_CONVERTERS);
            return new MapDeserializer(converters);
        }

        public IMapper Build() {
            var serializer = this.BuildSerializer();
            var deserializer = this.BuildDeserializer();
            return new Mapper(this._options, serializer, deserializer);
        }
    }
}

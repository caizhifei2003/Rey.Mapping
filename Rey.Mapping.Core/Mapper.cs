using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rey.Mapping.Core {
    public class Mapper : IMapper {
        private readonly IMapperOptions _options;
        private readonly IMapSerializer _serializer;

        public Mapper(
            IMapperOptions options,
            IMapSerializer serializer) {
            this._options = options;
            this._serializer = serializer;
        }

        public IMapNode From(object fromValue, Type fromType, ISerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return this._serializer.Serialize(fromValue, fromType, options);
        }
    }

    public class MapSerializer : IMapSerializer {
        private readonly IEnumerable<IMapConverter> _converters;
        private readonly IMapDeserializer _deserializer;

        public MapSerializer(
            IEnumerable<IMapConverter> converters,
            IMapDeserializer deserializer) {
            this._converters = converters;
            this._deserializer = deserializer;
        }

        public IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));


            var converter = this._converters.FirstOrDefault(x => x.CanSerialize(fromValue, fromType, options));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[type: {fromType}][value: {fromValue}]");

            var context = new MapSerializeContext(this);
            return converter.Serialize(fromValue, fromType, options, context);
        }
    }

    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;

        public MapSerializeContext(IMapSerializer serializer) {
            this._serializer = serializer;
        }

        public IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options) {
            return this._serializer.Serialize(fromValue, fromType, options);
        }
    }
}

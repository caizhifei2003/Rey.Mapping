using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapSerializer : IMapSerializer {
        private readonly IEnumerable<IMapConverter> _converters;
        private readonly IMapDeserializer _deserializer;

        public MapSerializer(
            IEnumerable<IMapConverter> converters,
            IMapDeserializer deserializer) {
            this._converters = converters;
            this._deserializer = deserializer;
        }

        public IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));


            var converter = this._converters.FirstOrDefault(x => x.CanSerialize(fromValue, fromType, options));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[value: {fromValue}][type: {fromType}]");

            var context = new MapSerializeContext(this, this._deserializer);
            return converter.Serialize(fromValue, fromType, options, context);
        }
    }
}

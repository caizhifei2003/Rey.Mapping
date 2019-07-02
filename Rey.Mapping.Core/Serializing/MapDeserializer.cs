using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapDeserializer : IMapDeserializer {
        private readonly IEnumerable<IMapConverter> _converters;

        public MapDeserializer(IEnumerable<IMapConverter> converters) {
            this._converters = converters;
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context = null) {
            var converter = this._converters.FirstOrDefault(x => x.CanDeserialize(token, toType, options));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[node: {token}][type: {toType}]");

            context = context ?? new MapDeserializeContext(this);
            return converter.Deserialize(token, toType, options, context);
        }
    }
}

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

        public object Deserialize(IMapNode node, Type toType, IMapDeserializeOptions options) {
            var converter = this._converters.FirstOrDefault(x => x.CanDeserialize(node, toType, options));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[node: {node}][type: {toType}]");

            var context = new MapDeserializeContext(this);
            return converter.Deserialize(node, toType, options, context);
        }
    }
}

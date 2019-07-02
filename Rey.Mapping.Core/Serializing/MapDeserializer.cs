using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapDeserializer : IMapDeserializer {
        private readonly IEnumerable<IMapDeserializeConverter> _converters;

        public MapDeserializer(IEnumerable<IMapDeserializeConverter> converters) {
            this._converters = converters;
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var converter = this._converters.FirstOrDefault(x => x.CanDeserialize(path, toType, options, context));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[node: {path}][type: {toType}]");

            return converter.Deserialize(path, toType, options, context);
        }
    }
}

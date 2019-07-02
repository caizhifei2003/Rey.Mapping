using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapSerializer : IMapSerializer {
        private readonly IEnumerable<IMapConverter> _converters;

        public MapSerializer(IEnumerable<IMapConverter> converters) {
            this._converters = converters;
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context = null) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var converter = this._converters.FirstOrDefault(x => x.CanSerialize(fromValue, fromType, options));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[value: {fromValue}][type: {fromType}]");

            context = context ?? new MapSerializeContext(this);
            return converter.Serialize(fromValue, fromType, options, context);
        }
    }
}

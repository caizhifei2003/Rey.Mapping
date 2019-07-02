using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapSerializer : IMapSerializer {
        private readonly IEnumerable<IMapSerializeConverter> _converters;

        public MapSerializer(IEnumerable<IMapSerializeConverter> converters) {
            this._converters = converters;
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var converter = this._converters.FirstOrDefault(x => x.CanSerialize(path, fromValue, fromType, options, context));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[value: {fromValue}][type: {fromType}]");

            converter.Serialize(path, fromValue, fromType, options, context);
        }
    }
}

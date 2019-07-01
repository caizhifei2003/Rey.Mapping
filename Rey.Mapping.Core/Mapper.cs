using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public class Mapper : IMapper {
        private readonly IMapperOptions _options;
        private readonly IMapSerializer _serializer;

        public Mapper(
            IMapperOptions options,
            IMapSerializer serializer) {
            this._options = options;
            this._serializer = serializer;
        }

        public IMapToken From(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return this._serializer.Serialize(fromValue, fromType, options);
        }
    }
}

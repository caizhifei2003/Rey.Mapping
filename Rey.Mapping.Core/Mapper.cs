using System;

namespace Rey.Mapping {
    public class Mapper : IMapper {
        private readonly IMapperOptions _options;
        private readonly IMapSerializer _serializer;
        private readonly IMapDeserializer _deserializer;

        public Mapper(IMapperOptions options, IMapSerializer serializer, IMapDeserializer deserializer) {
            this._options = options;
            this._serializer = serializer;
            this._deserializer = deserializer;
        }

        public IMapTokenWrapper From(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var token = this._serializer.Serialize(fromValue, fromType, options);
            return new MapTokenWrapper(token, this._deserializer);
        }
    }
}

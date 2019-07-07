using System;

namespace Rey.Mapping {
    public class Mapper : IMapper {
        private readonly IMapperOptions _options;
        private readonly IMapSerializer _serializer;
        private readonly IMapDeserializer _deserializer;
        private readonly IMapConfig _config;

        public Mapper(
            IMapperOptions options,
            IMapSerializer serializer,
            IMapDeserializer deserializer,
            IMapConfig config) {
            this._options = options;
            this._serializer = serializer;
            this._deserializer = deserializer;
            this._config = config;
        }

        private IMapTable Serialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var table = new MapTable();
            var context = new MapSerializeContext(this._serializer, table);
            this._config.AttachTo(fromType, options);
            this._serializer.Serialize(MapPath.Root, fromValue, fromType, options, context);
            return table.AfterSerialize(options);
        }

        public IMapMedia From(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return new MapMedia(
                this.Serialize(fromValue, fromType, options),
                this._deserializer,
                this._options,
                this._config);
        }

        public IMapMedia From(object fromValue, Type fromType, Action<IMapSerializeOptions> configure = null) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            return this.From(fromValue, fromType, new MapSerializeOptions().Configure(configure));
        }

        public IMapMedia<TFrom> From<TFrom>(TFrom fromValue, IMapSerializeOptions<TFrom> options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return new MapMedia<TFrom>(
                this.Serialize(fromValue, typeof(TFrom), options),
                this._deserializer,
                this._options,
                this._config);
        }

        public IMapMedia<TFrom> From<TFrom>(TFrom fromValue, Action<IMapSerializeOptions<TFrom>> configure = null) {
            return this.From(fromValue, new MapSerializeOptions<TFrom>().Configure(configure));
        }
    }
}

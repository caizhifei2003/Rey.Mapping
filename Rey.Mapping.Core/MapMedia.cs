using System;

namespace Rey.Mapping {
    public class MapMedia : IMapMedia {
        private readonly IMapTable _table;
        private readonly IMapDeserializer _deserializer;
        private readonly IMapperOptions _options;
        private readonly IMapConfig _config;

        public MapMedia(
            IMapTable table,
            IMapDeserializer deserializer,
            IMapperOptions options,
            IMapConfig config) {
            this._table = table;
            this._deserializer = deserializer;
            this._options = options;
            this._config = config;
        }

        public object To(Type toType, IMapDeserializeOptions options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            this._config.AttachTo(toType, options);
            var context = new MapDeserializeContext(this._deserializer, this._table.BeforeDeserialize(options));
            return this._deserializer.Deserialize(MapPath.Root, toType, options, context);
        }
    }

    public class MapMedia<TFrom> : MapMedia, IMapMedia<TFrom> {
        public MapMedia(
            IMapTable table,
            IMapDeserializer deserializer,
            IMapperOptions options,
            IMapConfig config)
            : base(table, deserializer, options, config) {
        }

        public object To(Type toType, IMapDeserializeOptions<TFrom> options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return this.To(toType, (IMapDeserializeOptions)options);
        }

        public object To(Type toType, Action<IMapDeserializeOptions<TFrom>> configure = null) {
            return this.To(toType, new MapDeserializeOptions<TFrom>().Configure(configure));
        }

        public TTo To<TTo>(IMapDeserializeOptions<TFrom, TTo> options) {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return (TTo)this.To(typeof(TTo), (IMapDeserializeOptions<TFrom>)options);
        }

        public TTo To<TTo>(Action<IMapDeserializeOptions<TFrom, TTo>> configure = null) {
            return this.To<TTo>(new MapDeserializeOptions<TFrom, TTo>().Configure(configure));
        }
    }
}

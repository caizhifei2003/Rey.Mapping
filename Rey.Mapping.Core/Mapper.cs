using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping.Core {
    public class Mapper : IMapper {
        private readonly IMapperOptions _options;
        private readonly IMapSerializer _serializer;

        public Mapper(
            IMapperOptions options,
            IMapSerializer serializer) {
            this._options = options;
            this._serializer = serializer;
        }

        public IMapTree From(object from, Type type = null, ISerializeOptions options = null) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            return this._serializer.Serialize(from, type, options);
        }
    }

    public class MapTree : IMapTree {
        private readonly IMapTreeNode _root;
        private readonly IMapDeserializer _deserializer;

        public MapTree(
            IMapTreeNode root,
            IMapDeserializer deserializer
            ) {
            this._root = root;
            this._deserializer = deserializer;
        }

        public object To(Type type, IDeserializeOptions options = null) {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return this._deserializer.Deserialize(this, type, options);
        }
    }

    public class MapSerializer : IMapSerializer {
        private readonly IEnumerable<IMapConverter> _converters;
        private readonly IMapDeserializer _deserializer;

        public MapSerializer(
            IEnumerable<IMapConverter> converters,
            IMapDeserializer deserializer) {
            this._converters = converters;
            this._deserializer = deserializer;
        }

        public IMapTree Serialize(object value, Type type = null, ISerializeOptions options = null, IMapSerializeContext context = null) {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            type = type ?? value.GetType();
            foreach (var converter in this._converters) {
                if (converter.CanSerialize(value, type)) {
                    var root = converter.Serialize(value, type, context ?? new MapSerializeContext(this, value, type, options));
                    return new MapTree(root, this._deserializer);
                }
            }

            throw new NotImplementedException("未找到转换器");
        }
    }

    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;

        public object FromValue { get; }
        public Type FromType { get; }
        public ISerializeOptions Options { get; }

        public MapSerializeContext(
            IMapSerializer serializer,
            object fromValue,
            Type fromType,
            ISerializeOptions options) {
            this._serializer = serializer;
            this.FromValue = fromValue;
            this.FromType = fromType;
            this.Options = options;
        }

        public void Serialize(object value, Type type = null) {
            this._serializer.Serialize(value, type, null, this);
        }
    }
}

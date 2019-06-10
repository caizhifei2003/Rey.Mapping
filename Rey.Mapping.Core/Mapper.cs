using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IMapNode From(object fromValue, Type fromType, ISerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return this._serializer.Serialize(fromValue, fromType, options);
        }
    }

    public class MapperOptions : IMapperOptions {

    }

    public class SerializeOptions : ISerializeOptions {

    }

    public class DeserializeOptions : IDeserializeOptions {

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

        public IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options) {
            if (fromValue == null)
                throw new ArgumentNullException(nameof(fromValue));

            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            if (options == null)
                throw new ArgumentNullException(nameof(options));


            var converter = this._converters.FirstOrDefault(x => x.CanSerialize(fromValue, fromType, options));
            if (converter == null)
                throw new InvalidOperationException($"无法找到转换器。[type: {fromType}][value: {fromValue}]");

            var context = new MapSerializeContext(this, this._deserializer);
            return converter.Serialize(fromValue, fromType, options, context);
        }
    }

    public class MapSerializeContext : IMapSerializeContext {
        private readonly IMapSerializer _serializer;
        private readonly IMapDeserializer _deserializer;

        public MapSerializeContext(IMapSerializer serializer, IMapDeserializer deserializer) {
            this._serializer = serializer;
            this._deserializer = deserializer;
        }

        public IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options) {
            return this._serializer.Serialize(fromValue, fromType, options);
        }

        public IMapNode CreateNode(IMapToken token) {
            return new MapNode(token, this._deserializer);
        }
    }

    public class MapDeserializer : IMapDeserializer {
        public object Deserialize(IMapNode node, Type toType, IDeserializeOptions options) {
            throw new NotImplementedException();
        }
    }

    public class MapNode : IMapNode {
        private readonly IMapDeserializer _deserializer;

        public IMapToken Token { get; }

        public MapNode(IMapToken token, IMapDeserializer deserializer) {
            this.Token = token;
            this._deserializer = deserializer;
        }

        public object To(Type toType, IDeserializeOptions options) {
            return this._deserializer.Deserialize(this, toType, options);
        }
    }

    public abstract class MapConverter<T> : IMapConverter {
        public virtual bool CanSerialize(object fromValue, Type fromType, ISerializeOptions options) {
            return typeof(T).Equals(fromType);
        }

        public abstract IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options, IMapSerializeContext context);
    }

    public class MapStringConverter : MapConverter<string> {
        public override IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options, IMapSerializeContext context) {
            return context.CreateNode(new MapStringToken($"{fromValue}", fromType));
        }
    }

    public abstract class MapToken : IMapToken {

    }

    public abstract class MapToken<TValue> : MapToken, IMapToken<TValue> {
        public TValue FromValue { get; }
        public Type FromType { get; }

        public MapToken(TValue fromValue, Type fromType) {
            this.FromValue = fromValue;
            this.FromType = fromType;
        }
    }

    public class MapStringToken : MapToken<string> {
        public MapStringToken(string fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapBoolToken : MapToken<bool> {
        public MapBoolToken(bool fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapInt8Token : MapToken<SByte> {
        public MapInt8Token(SByte fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapInt16Token : MapToken<Int16> {
        public MapInt16Token(Int16 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapInt32Token : MapToken<Int32> {
        public MapInt32Token(Int32 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapInt64Token : MapToken<Int64> {
        public MapInt64Token(Int64 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapUInt8Token : MapToken<Byte> {
        public MapUInt8Token(Byte fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapUInt16Token : MapToken<UInt16> {
        public MapUInt16Token(UInt16 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapUInt32Token : MapToken<UInt32> {
        public MapUInt32Token(UInt32 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapUInt64Token : MapToken<UInt64> {
        public MapUInt64Token(UInt64 fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapSingleToken : MapToken<Single> {
        public MapSingleToken(Single fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapDoubleToken : MapToken<Double> {
        public MapDoubleToken(Double fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }

    public class MapDecimalToken : MapToken<Decimal> {
        public MapDecimalToken(Decimal fromValue, Type fromType)
            : base(fromValue, fromType) {
        }
    }


    public class MapNullToken : MapToken {

    }

    public class MapNullableToken<TValue> : MapToken {
        public MapToken<TValue> Token { get; }

        public MapNullableToken(MapToken<TValue> token) {
            this.Token = token;
        }
    }

    public class MapArrayToken : MapToken {
        public IReadOnlyList<IMapToken> Tokens { get; }

        public MapArrayToken(IEnumerable<IMapToken> tokens) {
            this.Tokens = new List<IMapToken>(tokens);
        }
    }

    public class MapObjectToken : MapToken {
        public IReadOnlyDictionary<string, IMapToken> Tokens { get; }

        public MapObjectToken(IEnumerable<KeyValuePair<string, IMapToken>> tokens) {
            this.Tokens = new Dictionary<string, IMapToken>(tokens);
        }
    }
}

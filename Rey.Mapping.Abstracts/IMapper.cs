using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping {
    public interface IMapper {
        IMapNode From(object fromValue, Type fromType, ISerializeOptions options);
    }

    public interface IMapSerializer {
        IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options);
    }

    public interface IMapDeserializer {
        object Deserialize(IMapNode node, Type toType, IDeserializeOptions options);
    }

    public interface ISerializeOptions {

    }

    public interface IDeserializeOptions {

    }

    public interface IMapperOptions {

    }

    public interface IMapNode {
        IMapToken Token { get; }

        object To(Type toType, IDeserializeOptions options);
    }

    public interface IMapToken {
        string GetStringValue();
    }

    public interface IMapToken<TValue> : IMapToken {
        TValue FromValue { get; }
        Type FromType { get; }
    }

    public interface IMapConverter {
        bool CanSerialize(object fromValue, Type fromType, ISerializeOptions options);
        IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options, IMapSerializeContext context);

        bool CanDeserialize(IMapNode node, Type toType, IDeserializeOptions options);
        object Deserialize(IMapNode node, Type toType, IDeserializeOptions options, IMapDeserializeContext context);
    }

    public interface IMapSerializeContext {
        IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options);
        IMapNode CreateNode(IMapToken token);
    }

    public interface IMapDeserializeContext {
        object Deserialize(IMapNode node, Type toType, IDeserializeOptions options);
    }
}

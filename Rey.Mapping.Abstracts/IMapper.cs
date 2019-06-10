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
        object Value { get; }
        object Type { get; }
        IReadOnlyList<IMapNode> Children { get; }

        object To(Type type, IDeserializeOptions options = null);
    }

    public interface IMapConverter {
        bool CanSerialize(object fromValue, Type fromType, ISerializeOptions options);
        IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options, IMapSerializeContext context);
    }

    public interface IMapSerializeContext {
        IMapNode Serialize(object fromValue, Type fromType, ISerializeOptions options);
    }

    public interface IMapDeserializeContext {

    }
}

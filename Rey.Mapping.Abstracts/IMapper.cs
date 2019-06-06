using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping {
    public interface IMapper {
        IMapTree From(object from, Type type = null, ISerializeOptions options = null);
    }

    public interface IMapSerializer {
        IMapTree Serialize(object value, Type type = null, ISerializeOptions options = null, IMapSerializeContext context = null);
    }

    public interface IMapDeserializer {
        object Deserialize(IMapTree tree, Type type, IDeserializeOptions options);
    }

    public interface ISerializeOptions {

    }

    public interface IDeserializeOptions {

    }

    public interface IMapperOptions {

    }

    public interface IMapTree {
        object To(Type type, IDeserializeOptions options = null);
    }

    public interface IMapTreeNode {
        object Value { get; }
        object Type { get; }
        IReadOnlyList<IMapTreeNode> Children { get; }
    }

    public interface IMapConverter {
        bool CanSerialize(object value, Type type);
        IMapTreeNode Serialize(object value, Type type, IMapSerializeContext context);
    }

    public interface IMapSerializeContext {
        object FromValue { get; }
        Type FromType { get; }
        ISerializeOptions Options { get; }

        void Serialize(object value, Type type = null);
    }

    public interface IMapDeserializeContext {

    }
}

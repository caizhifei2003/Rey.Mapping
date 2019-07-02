using System;

namespace Rey.Mapping {
    public interface IMapDeserializeContext {
        IMapTable Table { get; }
        object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options);
    }
}

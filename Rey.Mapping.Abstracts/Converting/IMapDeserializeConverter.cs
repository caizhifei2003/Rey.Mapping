using System;

namespace Rey.Mapping {
    public interface IMapDeserializeConverter {
        bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context);
        object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context);
    }
}

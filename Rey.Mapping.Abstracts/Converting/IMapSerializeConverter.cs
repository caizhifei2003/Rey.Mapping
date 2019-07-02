using System;

namespace Rey.Mapping {
    public interface IMapSerializeConverter {
        bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context);
        void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context);
    }
}

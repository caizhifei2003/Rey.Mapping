using System;

namespace Rey.Mapping {
    public interface IMapSerializeContext {
        IMapTable Table { get; }
        void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

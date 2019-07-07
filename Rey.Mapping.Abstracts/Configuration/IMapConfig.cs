using System;

namespace Rey.Mapping {
    public interface IMapConfig {
        IMapConfig Ignore(Type type, MapPath path);
        IMapConfig IgnoreFrom(Type type, MapPath path);
        IMapConfig IgnoreTo(Type type, MapPath path);

        IMapConfig AttachTo(Type type, IMapSerializeOptions options);
        IMapConfig AttachTo(Type type, IMapDeserializeOptions options);
    }
}

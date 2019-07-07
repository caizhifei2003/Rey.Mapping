using System;

namespace Rey.Mapping {
    public interface IMapperBuilder {
        IMapper Build();

        IMapperBuilder AddSerializeConverter(Func<IMapSerializeConverter> converter, int order = 0);
        IMapperBuilder AddSerializeConverter(IMapSerializeConverter converter, int order = 0);

        IMapperBuilder AddDeserializeConverter(Func<IMapDeserializeConverter> converter, int order = 0);
        IMapperBuilder AddDeserializeConverter(IMapDeserializeConverter converter, int order = 0);

        IMapperBuilder Ignore(Type type, MapPath path);
        IMapperBuilder IgnoreFrom(Type type, MapPath path);
        IMapperBuilder IgnoreTo(Type type, MapPath path);
    }
}

using System;

namespace Rey.Mapping {
    public interface IMapperBuilder {
        IMapperBuilder AddSerializeConverter(Func<IMapSerializeConverter> converter, int order = 0);
        IMapperBuilder AddSerializeConverter(IMapSerializeConverter converter, int order = 0);

        IMapperBuilder AddDeserializeConverter(Func<IMapDeserializeConverter> converter, int order = 0);
        IMapperBuilder AddDeserializeConverter(IMapDeserializeConverter converter, int order = 0);
    }
}

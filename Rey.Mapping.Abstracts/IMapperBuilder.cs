namespace Rey.Mapping {
    public interface IMapperBuilder {
        IMapper Build();
        IMapperBuilder FromMapper<TFromMapper>() where TFromMapper : class, IFromMapper;
        IMapperBuilder ToMapper<TToMapper>() where TToMapper : class, IToMapper;
    }
}

namespace Rey.Mapping {
    public interface IFromMapper {
        bool Filter(IMapFrom from);
        IMapToken MapToContract(IMapFrom from, IMapValueTable values, IMapToken parent = null);
    }
}

namespace Rey.Mapping {
    public interface IFromMapper {
        bool Filter(IMapFrom from);
        IMapContract MapToContract(IMapFrom from);
    }
}

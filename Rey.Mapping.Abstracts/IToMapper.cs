namespace Rey.Mapping {
    public interface IToMapper {
        bool Filter(IMapTo to);
        object MapToResult(IMapTo to, IMapContract contract);
    }
}

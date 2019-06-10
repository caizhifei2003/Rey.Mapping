namespace Rey.Mapping {
    public interface IMapToken {
        bool IsNull { get; }

        string GetStringValue();
    }
}

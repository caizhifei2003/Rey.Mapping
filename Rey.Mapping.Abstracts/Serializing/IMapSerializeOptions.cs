namespace Rey.Mapping {
    public interface IMapSerializeOptions {
        IMapSerializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);
    }
}

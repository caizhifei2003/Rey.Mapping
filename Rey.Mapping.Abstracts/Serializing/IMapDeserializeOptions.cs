namespace Rey.Mapping {
    public interface IMapDeserializeOptions {
        IMapDeserializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);
    }
}

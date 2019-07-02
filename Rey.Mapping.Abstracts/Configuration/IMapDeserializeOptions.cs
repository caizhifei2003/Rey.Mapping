namespace Rey.Mapping.Configuration {
    public interface IMapDeserializeOptions {
        IMapDeserializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);
    }
}

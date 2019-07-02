namespace Rey.Mapping.Configuration {
    public interface IMapSerializeOptions {
        IMapSerializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);

        IMapSerializeOptions Map(MapPath from, MapPath to);
        MapPath MapTo(MapPath from);
    }
}

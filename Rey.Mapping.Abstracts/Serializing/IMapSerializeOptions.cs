using System.Collections.Generic;

namespace Rey.Mapping {
    public interface IMapSerializeOptions {
        IMapSerializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);

        IMapSerializeOptions Map(MapPath from, IEnumerable<MapPath> to);
        IMapSerializeOptions Map(MapPath from, params MapPath[] to);
        IEnumerable<MapPath> GetMapPaths(MapPath path);
    }
}

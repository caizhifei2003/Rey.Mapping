using System.Collections.Generic;

namespace Rey.Mapping {
    public interface IMapTable : IEnumerable<KeyValuePair<MapPath, IMapToken>> {
        void AddToken(MapPath path, IMapToken token);
        IMapToken GetToken(MapPath path);
        IEnumerable<KeyValuePair<MapPath, IMapToken>> GetChildren(MapPath path);
    }
}

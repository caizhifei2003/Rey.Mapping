using System.Collections.Generic;

namespace Rey.Mapping {
    public interface IMapTable : IEnumerable<KeyValuePair<MapPath, IMapToken>> {
        void AddToken(MapPath path, IMapToken token);
        IMapToken GetToken(MapPath path);
    }
}

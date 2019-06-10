using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapArrayToken : MapToken {
        public IReadOnlyList<IMapToken> Tokens { get; }

        public MapArrayToken(IEnumerable<IMapToken> tokens) {
            this.Tokens = new List<IMapToken>(tokens);
        }
    }
}

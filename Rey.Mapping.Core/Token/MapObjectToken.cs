using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapObjectToken : MapToken {
        public IReadOnlyDictionary<string, IMapToken> Tokens { get; }

        public MapObjectToken(IEnumerable<KeyValuePair<string, IMapToken>> tokens) {
            this.Tokens = new Dictionary<string, IMapToken>(tokens);
        }

        public override bool Compatible(Type type) {
            throw new NotImplementedException();
        }

        public override object GetValue(Type type) {
            throw new NotImplementedException();
        }
    }
}

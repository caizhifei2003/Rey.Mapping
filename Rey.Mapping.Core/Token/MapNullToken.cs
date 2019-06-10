using System;

namespace Rey.Mapping {
    public class MapNullToken : MapValueToken {
        public override bool IsNull => true;

        public MapNullToken(Type fromType)
            : base(fromType) {
        }
    }
}

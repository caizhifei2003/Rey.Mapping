using System;

namespace Rey.Mapping {
    public class MapMedia : IMapMedia {
        private readonly IMapToken _token;
        private readonly IMapDeserializer _deserializer;

        public MapMedia(IMapToken token, IMapDeserializer deserializer) {
            this._token = token;
            this._deserializer = deserializer;
        }

        public object To(Type toType, IMapDeserializeOptions options) {
            return this._deserializer.Deserialize(this._token, toType, options);
        }
    }
}

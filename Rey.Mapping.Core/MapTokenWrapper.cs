using System;

namespace Rey.Mapping {
    public class MapTokenWrapper : IMapTokenWrapper {
        private readonly IMapToken _token;
        private readonly IMapDeserializer _deserializer;

        public MapTokenWrapper(IMapToken token, IMapDeserializer deserializer) {
            this._token = token;
            this._deserializer = deserializer;
        }

        public object To(Type toType, IMapDeserializeOptions options) {
            return this._deserializer.Deserialize(this._token, toType, options);
        }
    }


}

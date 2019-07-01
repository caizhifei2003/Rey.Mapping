using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapStringConverter : IMapConverter {
        private static readonly IEnumerable<Type> TYPES = new List<Type>() {
            typeof(char),
            typeof(string),
            typeof(DateTime),
            typeof(TimeSpan)
        };

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            if (fromType == null)
                throw new ArgumentNullException(nameof(fromType));

            return TYPES.Any(x => x.Equals(fromType));
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return new MapStringToken($"{fromValue}", fromType);
        }

        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return TYPES.Any(x => x.Equals(toType));
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var stringToken = token as MapStringToken;
            var value = stringToken.Value;
            if (typeof(char).Equals(toType))
                return char.Parse(value);

            if (typeof(DateTime).Equals(toType))
                return DateTime.Parse(value);

            if (typeof(TimeSpan).Equals(toType))
                return TimeSpan.Parse(value);

            return value;
        }
    }
}

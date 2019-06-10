using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapNumberConverter : IMapConverter {
        private static readonly IEnumerable<Type> TYPES_FLOAT = new List<Type>() {
            typeof(Single),
            typeof(Double),
            typeof(Decimal)
        };

        private static readonly IEnumerable<Type> TYPES_SIGNED = new List<Type>() {
            typeof(SByte),
            typeof(Int16),
            typeof(Int32),
            typeof(Int64)
        };

        private static readonly IEnumerable<Type> TYPES_UNSIGNED = new List<Type>() {
            typeof(Byte),
            typeof(UInt16),
            typeof(UInt32),
            typeof(UInt64)
        };

        private static readonly IEnumerable<Type> TYPES = TYPES_FLOAT
            .Union(TYPES_SIGNED)
            .Union(TYPES_UNSIGNED);

        public bool CanDeserialize(IMapNode node, Type toType, IMapDeserializeOptions options) {
            throw new NotImplementedException();
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return TYPES.Any(x => x.Equals(fromType));
        }

        public object Deserialize(IMapNode node, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            throw new NotImplementedException();
        }

        public IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            throw new NotImplementedException();
        }
    }
}

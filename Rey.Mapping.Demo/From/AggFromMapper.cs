using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class AggFromMapper : IAggFromMapper {
        private IEnumerable<IFromMapper> Mappers { get; }

        public AggFromMapper(IEnumerable<IFromMapper> mappers) {
            this.Mappers = new List<IFromMapper>(mappers);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            var mapper = this.Mappers.FirstOrDefault(x => x.CanMapFrom(type, path));
            if (mapper == null)
                throw new InvalidOperationException("cannot find mapper.");

            mapper.MapFrom(type, value, path, context);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class AggFromMapper : IAggFromMapper {
        private IEnumerable<IFromMapper> Mappers { get; }

        public AggFromMapper(IEnumerable<IFromMapper> mappers) {
            this.Mappers = new List<IFromMapper>(mappers);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            var succeeded = false;
            foreach (var mapper in this.Mappers) {
                try {
                    mapper.MapFrom(type, value, path, context);
                    succeeded = true;
                    return;
                } catch (MapFromFailedException) {
                    continue;
                }
            }

            if (!succeeded)
                throw new MapFromFailedException();
        }
    }
}

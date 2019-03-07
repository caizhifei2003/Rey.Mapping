using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class AggToMapper : IAggToMapper {
        private IEnumerable<IToMapper> Mappers { get; }

        public AggToMapper(IEnumerable<IToMapper> mappers) {
            this.Mappers = new List<IToMapper>(mappers);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var mapper = this.Mappers.FirstOrDefault(x => x.CanMapTo(type, path));
            if (mapper == null)
                throw new InvalidOperationException("cannot find mapper.");

            return mapper.MapTo(type, path, context);
        }
    }
}

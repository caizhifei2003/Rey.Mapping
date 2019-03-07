using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class AggToMapper : IAggToMapper {
        private IEnumerable<IToMapper> Mappers { get; }

        public AggToMapper(IEnumerable<IToMapper> mappers) {
            this.Mappers = new List<IToMapper>(mappers);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            foreach (var mapper in this.Mappers) {
                try {
                    return mapper.MapTo(type, path, context);
                } catch (MapToFailedException) {
                    continue;
                }
            }
            throw new MapToFailedException();
        }
    }
}

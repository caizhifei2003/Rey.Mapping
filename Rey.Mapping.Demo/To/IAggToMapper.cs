using System;

namespace Rey.Mapping {
    public interface IAggToMapper {
        object MapTo(Type type, MapPath path, MapToContext context);
    }
}

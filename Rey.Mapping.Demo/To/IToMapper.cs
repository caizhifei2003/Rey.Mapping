using System;

namespace Rey.Mapping {
    public interface IToMapper {
        object MapTo(Type type, MapPath path, MapToContext context);
    }
}

using System;

namespace Rey.Mapping {
    public interface IToMapper {
        bool CanMapTo(Type type, MapPath path);
        object MapTo(Type type, MapPath path, MapToContext context);
    }
}

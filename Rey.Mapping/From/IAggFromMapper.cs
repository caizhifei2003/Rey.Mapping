using System;

namespace Rey.Mapping {
    public interface IAggFromMapper {
        void MapFrom(Type type, object value, MapPath path, MapFromContext context);
    }
}

using System;

namespace Rey.Mapping {
    public interface IFromMapper {
        void MapFrom(Type type, object value, MapPath path, MapFromContext context);
    }
}

using System;

namespace Rey.Mapping {
    public interface IFromMapper {
        bool CanMapFrom(Type type, MapPath path);
        void MapFrom(Type type, object value, MapPath path, MapFromContext context);
    }
}

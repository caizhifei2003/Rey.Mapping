using System;
using System.Reflection;

namespace Rey.Mapping {
    public class FromArrayMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return type.IsArray;
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (value == null) {
                context.Values.AddValue(path, new MapNullValue());
                return;
            }

            var elemType = type.GetElementType();
            var length = (int)type.GetProperty("Length").GetValue(value);
            context.Values.AddValue(path, new MapArrayValue(length));

            var mGet = type.GetMethod("Get", BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < length; ++i) {
                var elem = mGet.Invoke(value, new object[] { i });
                context.Mapper.MapFrom(elemType, elem, path.Join($"[{i}]"), context);
            }
        }
    }
}

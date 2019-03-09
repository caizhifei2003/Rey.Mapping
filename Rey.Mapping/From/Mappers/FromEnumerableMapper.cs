using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class FromEnumerableMapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            if (typeof(string).Equals(type))
                return false;

            if (type.IsInterface)
                return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>));

            return type
                .GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)));
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            Type elemType = null;

            if (type.IsInterface) {
                elemType = type.GetGenericArguments()[0];
            } else {
                var tInterface = type.GetInterfaces().FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)));
                elemType = tInterface.GetGenericArguments()[0];
            }

            var tArr = elemType.MakeArrayType();
            var mToArray = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(elemType);
            var arr = mToArray.Invoke(null, new object[] { value });
            context.MapFrom(tArr, arr, path);
        }
    }
}

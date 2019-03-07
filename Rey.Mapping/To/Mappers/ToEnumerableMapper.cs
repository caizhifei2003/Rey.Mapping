using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class ToEnumerableMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            if (typeof(string).Equals(type))
                return false;

            if (type.IsInterface)
                return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>));

            return type
                .GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)));
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            Type elemType = null;

            if (type.IsInterface) {
                elemType = type.GetGenericArguments()[0];
            } else {
                var tInterface = type.GetInterfaces().FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)));
                elemType = tInterface.GetGenericArguments()[0];
            }

            var tArr = elemType.MakeArrayType();
            var arr = context.Mapper.MapTo(tArr, path, context);
            var mToList = typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(elemType);
            var list = mToList.Invoke(null, new object[] { arr });
            //var ret = Convert.ChangeType(list, type);
            return list;
        }
    }
}

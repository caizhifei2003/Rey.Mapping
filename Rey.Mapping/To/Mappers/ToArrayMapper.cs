using System;
using System.Reflection;

namespace Rey.Mapping {
    public class ToArrayMapper : IToMapper {
        public bool CanMapTo(Type type, MapPath path) {
            return type.IsArray;
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            var value = context.Values.GetValue(path);
            if (!value.IsArray)
                throw new InvalidOperationException();

            var length = (value as MapArrayValue).Length;
            var elemType = type.GetElementType();

            var tArr = elemType.MakeArrayType();
            var arr = Activator.CreateInstance(tArr, new object[] { length });
            var mSet = tArr.GetMethod("Set", BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < length; ++i) {
                var elem = context.MapTo(elemType, path.Join(i));
                mSet.Invoke(arr, new object[] { i, elem });
            }

            return arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    internal static class ArrayUtil {
        public static bool IsArray(Type type) {
            return type.IsArray;
        }

        public static Type GetEnumerableType(Type type) {
            bool verify(Type t) => t.IsGenericType && typeof(IEnumerable<>).Equals(t.GetGenericTypeDefinition());
            return verify(type) ? type : type.GetInterfaces().FirstOrDefault(verify);
        }

        public static bool IsEnumerable(Type type) {
            return GetEnumerableType(type) != null;
        }

        public static bool Check(Type type) {
            return IsArray(type) || IsEnumerable(type);
        }

        public static Type GetElementType(Type type) {
            if (IsArray(type))
                return type.GetElementType();

            var eType = GetEnumerableType(type);
            if (eType != null)
                return eType.GetGenericArguments()[0];

            return null;
        }

        public static int GetCount(object arr) {
            return (int)arr.GetType().GetProperty("Length").GetValue(arr);
        }

        public static object GetValue(object arr, int index) {
            return arr.GetType().GetMethod("Get").Invoke(arr, new object[] { index });
        }

        public static void SetValue(object arr, int index, object value) {
            arr.GetType().GetMethod("Set").Invoke(arr, new object[] { index, value });
        }

        public static object ToArray(Type elemType, object target) {
            return typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(elemType).Invoke(null, new object[] { target });
        }

        public static object ToList(Type elemType, object target) {
            return typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(elemType).Invoke(null, new object[] { target });
        }
    }
}

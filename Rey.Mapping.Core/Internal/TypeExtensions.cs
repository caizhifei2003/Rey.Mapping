using System;

namespace Rey.Mapping {
    internal static class TypeExtensions {
        public static bool Equals<T>(this Type type) {
            return type.Equals(typeof(T));
        }

        public static bool IsNullable(this Type type) {
            return Nullable.GetUnderlyingType(type) != null;
        }
    }
}

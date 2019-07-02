using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping {
    internal static class TypeExtensions {
        public static bool Equals<T>(this Type type) {
            return type.Equals(typeof(T));
        }
    }
}

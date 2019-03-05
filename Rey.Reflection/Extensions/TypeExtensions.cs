using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Rey.Reflection {
    public static class TypeExtensions {
        public static IEnumerable<ReyProperty> ReyGetProperties(this Type type, BindingFlags flags) {
            return new ReyType(type).GetProperties(flags);
        }

        public static IEnumerable<ReyProperty> ReyGetProperties(this Type type) {
            return new ReyType(type).GetProperties();
        }

        public static IEnumerable<ReyField> ReyGetFields(this Type type, BindingFlags flags) {
            return new ReyType(type).GetFields(flags);
        }

        public static IEnumerable<ReyField> ReyGetFields(this Type type) {
            return new ReyType(type).GetFields();
        }

        public static IEnumerable<ReyMember> ReyGetMembers(this Type type, BindingFlags flags) {
            return new ReyType(type).GetMembers(flags);
        }

        public static IEnumerable<ReyMember> ReyGetMembers(this Type type) {
            return new ReyType(type).GetMembers();
        }
    }
}

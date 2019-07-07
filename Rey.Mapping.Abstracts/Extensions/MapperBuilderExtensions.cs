using System;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public static class MapperBuilderExtensions {
        public static IMapperBuilder Ignore<T>(this IMapperBuilder builder, Expression<Func<T, object>> field) {
            return builder.Ignore(typeof(T), MapPath.Parse(field));
        }

        public static IMapperBuilder IgnoreFrom<T>(this IMapperBuilder builder, Expression<Func<T, object>> field) {
            return builder.IgnoreFrom(typeof(T), MapPath.Parse(field));
        }

        public static IMapperBuilder IgnoreTo<T>(this IMapperBuilder builder, Expression<Func<T, object>> field) {
            return builder.IgnoreTo(typeof(T), MapPath.Parse(field));
        }
    }
}

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Rey.Mapping {
    public abstract class MapFrom {
        public abstract MapType Type { get; }
        public abstract object Value { get; }

        public static MapFrom Create<T>(T value) {
            return new MapObjectFrom(typeof(T), value);
        }

        public static MapFrom Create<T, TMember>(T value, Expression<Func<T, TMember>> member) {
            if (member.Body.NodeType != ExpressionType.MemberAccess)
                throw new InvalidOperationException();

            var exp = member.Body as MemberExpression;
            var info = exp.Member;
            if (info is PropertyInfo) {
                return new MapPropertyFrom(value, info as PropertyInfo);
            }

            if (info is FieldInfo) {
                return new MapFieldFrom(value, info as FieldInfo);
            }

            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public class MapPath : IEquatable<MapPath> {
        public IEnumerable<string> Segments { get; } = new List<string>();
        public char Separator { get; } = '.';
        public string PathString => string.Join(this.Separator, this.Segments);

        public MapPath() {
        }

        public MapPath(char separator) {
            this.Separator = separator;
        }

        public MapPath(IEnumerable<string> segments, char separator) {
            this.Segments = new List<string>(segments);
            this.Separator = separator;
        }

        public MapPath Join(MapPath other) {
            var segments = new List<string>();
            segments.AddRange(this.Segments);
            segments.AddRange(other.Segments);
            return new MapPath(segments, this.Separator);
        }

        public MapPath Join(int index) {
            return this.Join($"[{index}]");
        }

        public static MapPath Parse(string path, char separator = '.') {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var segments = path.Split(separator);
            return new MapPath(segments, separator);
        }

        private static MapPath Parse(MapPath path, Expression exp, char separator = '.') {
            if (exp.NodeType == ExpressionType.Lambda) {
                var expLambda = exp as LambdaExpression;
                return Parse(path, expLambda.Body, separator);
            }

            if (exp.NodeType == ExpressionType.Parameter) {
                return path;
            }

            if (exp.NodeType == ExpressionType.MemberAccess) {
                var expMember = exp as MemberExpression;
                var name = expMember.Member.Name;
                var expPath = MapPath.Parse(name).Join(path);
                if (expMember.Expression == null)
                    return expPath;

                return Parse(expPath, expMember.Expression, separator);
            }

            if (exp.NodeType == ExpressionType.Call) {
                var expMethod = exp as MethodCallExpression;
                if (expMethod.Method.Name.Equals("get_Item")) {
                    var expIndex = expMethod.Arguments[0] as ConstantExpression;
                    var index = (int)expIndex.Value;
                    var expPath = new MapPath().Join(index).Join(path);
                    if (expMethod.Object == null)
                        return expPath;

                    return Parse(expPath, expMethod.Object, separator);
                }
            }

            throw new NotImplementedException();
        }

        public static MapPath Parse<T>(Expression<Func<T, object>> field, char separator = '.') {
            if (field == null)
                throw new ArgumentNullException(nameof(field));

            return Parse(new MapPath(), field, separator);
        }

        public bool Equals(MapPath other) {
            return this.Equals((object)other);
        }

        public override int GetHashCode() {
            var hash = 0x10;
            hash = (hash * 0x0f) + this.PathString.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj) {
            if (base.Equals(obj))
                return true;

            if (obj == null)
                return false;

            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public override string ToString() {
            return this.PathString;
        }

        public static implicit operator MapPath(string path) {
            return MapPath.Parse(path);
        }

        public static MapPath operator +(MapPath path, string segment) {
            return path.Join(segment);
        }

        public static bool operator ==(MapPath path1, MapPath path2) {
            return path1.Equals(path2);
        }

        public static bool operator !=(MapPath path1, MapPath path2) {
            return !(path1 == path2);
        }
    }
}

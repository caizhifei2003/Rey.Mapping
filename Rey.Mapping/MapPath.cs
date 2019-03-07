using System;
using System.Collections.Generic;

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

        public MapPath Join(string segment) {
            var segments = new List<string>(this.Segments);
            segments.Add(segment);
            return new MapPath(segments, this.Separator);
        }

        public static MapPath Parse(string path, char separator = '.') {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var segments = path.Split(separator);
            return new MapPath(segments, separator);
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

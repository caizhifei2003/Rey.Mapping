using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rey.Mapping {
    public class MapPath : IEquatable<MapPath> {
        public const char SEPARATOR = '.';

        public static MapPath Empty { get; } = new MapPath();

        private readonly IReadOnlyList<MapPathSegment> _segments = new List<MapPathSegment>();
        private readonly char _separator;

        public string PathString => string.Join(this._separator, this._segments);

        public MapPath(char? separator = null) {
            this._separator = separator ?? SEPARATOR;
        }

        public MapPath(IEnumerable<MapPathSegment> segments, char? separator = null)
            : this(separator) {
            this._segments = new List<MapPathSegment>(segments);
        }

        public bool Equals(MapPath other) {
            return this.Equals((object)other);
        }

        public override int GetHashCode() {
            var hash = 0x10;
            foreach (var segment in this._segments) {
                hash = (hash * 0x0f) + (segment?.GetHashCode() ?? 0);
            }
            return hash;
        }

        public override bool Equals(object obj) {
            if (base.Equals(obj))
                return true;

            if (obj == null)
                return false;

            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public static bool operator ==(MapPath path1, MapPath path2) {
            return path1.Equals(path2);
        }

        public static bool operator !=(MapPath path1, MapPath path2) {
            return !(path1 == path2);
        }

        public static MapPath Parse(string path, char separator = SEPARATOR) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var segments = path
                .Split(separator)
                .Select(x => MapPathSegment.Parse(x));

            return new MapPath(segments, separator);
        }

        public MapPath Append(MapPathSegment segment) {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            var segments = this._segments.ToList();
            segments.Add(segment);
            return new MapPath(segments, this._separator);
        }

        public MapPath Append(string segment) {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            return this.Append(MapPathSegment.Parse(segment));
        }
    }
}

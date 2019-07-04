using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapPath {
        public static readonly string DELIMITER = ".";
        public static readonly MapPath Root = new MapPath();

        private readonly List<string> _segments;

        public bool IsEmpty => this._segments.Count == 0;

        public MapPath(IEnumerable<string> segments = null) {
            this._segments = segments?.ToList() ?? new List<string>();
        }

        public MapPath(MapPath other) 
            : this(other._segments) {
        }

        public MapPath Append(string segment) {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            var clone = this._segments.ToList();
            clone.Add(segment);
            return new MapPath(clone);
        }

        public MapPath Parent() {
            if (this.IsEmpty)
                return null;

            return new MapPath(this._segments.Take(this._segments.Count - 1));
        }

        public string LastSegment() {
            if (this.IsEmpty)
                return null;

            return this._segments.Last();
        }

        public override string ToString() {
            return string.Join('.', this._segments.Select(x => x));
        }

        public bool Equals(MapPath other) {
            return this.Equals((object)other);
        }

        public override int GetHashCode() {
            var hash = 0x10;
            hash = (hash * 0x0f) + this.ToString().GetHashCode();
            return hash;
        }

        public override bool Equals(object obj) {
            if (base.Equals(obj))
                return true;

            if (obj == null)
                return false;

            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public static MapPath Parse(string value) {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var segments = value.Split(DELIMITER);
            return new MapPath(segments);
        }

        public static implicit operator MapPath(string value) {
            return Parse(value);
        }

        public static bool operator ==(MapPath path1, MapPath path2) {
            return path1.Equals(path2);
        }

        public static bool operator !=(MapPath path1, MapPath path2) {
            return !(path1 == path2);
        }
    }
}

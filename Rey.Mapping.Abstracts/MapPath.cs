using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapPath {
        public static readonly string DELIMITER = ".";
        public static readonly MapPath Root = new MapPath();

        private readonly Stack<string> _segments;

        public MapPath(IEnumerable<string> segments = null) {
            if (segments != null) {
                this._segments = new Stack<string>(segments);
            } else {
                this._segments = new Stack<string>();
            }
        }

        public MapPath Push(string segment) {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            this._segments.Push(segment);
            return this;
        }

        public string Pop() {
            return this._segments.Pop();
        }

        public MapPath Append(string segment) {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            return new MapPath(this._segments).Push(segment);
        }

        public override string ToString() {
            return string.Join('.', this._segments.Reverse().Select(x => x));
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
    }
}

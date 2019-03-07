using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapPath {
        public IEnumerable<string> Segments { get; } = new List<string>();
        public string Separator { get; } = ".";
        public string PathString => string.Join(this.Separator, this.Segments);

        public MapPath() {
        }

        public MapPath(string separator) {
            this.Separator = separator;
        }

        public MapPath(IEnumerable<string> segments, string separator) {
            this.Segments = new List<string>(segments);
            this.Separator = separator;
        }

        public MapPath Join(string segment) {
            var segments = new List<string>(this.Segments);
            segments.Add(segment);
            return new MapPath(segments, this.Separator);
        }

        public static MapPath operator +(MapPath path, string segment) {
            return path.Join(segment);
        }
    }
}

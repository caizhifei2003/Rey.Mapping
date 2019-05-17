using System;
using System.Text.RegularExpressions;

namespace Rey.Mapping {
    public class MapPathSegment : IEquatable<MapPathSegment> {
        public const char KEY_PRE = '[';
        public const char KEY_POST = ']';
        public static readonly Regex REG_SEGMENT = new Regex($"(?<name>^[a-z][a-z0-9]*)(\\{KEY_PRE}(?<key>[a-z0-9]+)\\{KEY_POST})?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public string Name { get; }
        public string Key { get; }

        public string Value {
            get {
                var key = this.Key == null ? "" : $"{KEY_PRE}{this.Key}{KEY_POST}";
                return $"{this.Name}{key}";
            }
        }

        public MapPathSegment(string name, string key = null) {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name is null or empty", nameof(name));

            if (key != null && key == "")
                throw new ArgumentException("key is empty", nameof(key));

            this.Name = name;
            this.Key = key;
        }

        public bool Equals(MapPathSegment other) {
            return this.Equals((object)other);
        }

        public override int GetHashCode() {
            var hash = 0x10;
            hash = (hash * 0x0f) + (this.Name?.GetHashCode() ?? 0);
            return hash;
        }

        public override bool Equals(object obj) {
            if (base.Equals(obj))
                return true;

            if (obj == null)
                return false;

            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public static MapPathSegment Parse(string content) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var match = REG_SEGMENT.Match(content);
            if (!match.Success)
                throw new InvalidOperationException($"invalid segment content.");

            var gName = match.Groups["name"];
            var gKey = match.Groups["key"];

            if (!gName.Success)
                throw new InvalidOperationException($"invalid segment name.");

            return new MapPathSegment(gName.Value, gKey.Success ? gKey.Value : null);
        }
    }
}

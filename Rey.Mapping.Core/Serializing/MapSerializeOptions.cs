using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public class MapSerializeOptions : IMapSerializeOptions {
        private readonly List<MapPath> _ignores = new List<MapPath>();
        private readonly Dictionary<MapPath, List<MapPath>> _maps = new Dictionary<MapPath, List<MapPath>>();

        public IMapSerializeOptions Ignore(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            this._ignores.Add(path);
            return this;
        }

        public bool IsIgnore(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return this._ignores.Any(p => p.Equals(path));
        }

        public IMapSerializeOptions Map(MapPath from, IEnumerable<MapPath> to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            if (this._maps.ContainsKey(from)) {
                this._maps[from].AddRange(to);
            } else {
                this._maps.Add(from, new List<MapPath>(to));
            }

            return this;
        }

        public IMapSerializeOptions Map(MapPath from, params MapPath[] to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            return this.Map(from, to.AsEnumerable());
        }

        public IEnumerable<MapPath> GetMapPaths(MapPath path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (this._maps.TryGetValue(path, out var paths)) {
                return paths;
            }

            return new List<MapPath>() { new MapPath(path) };
        }
    }

    public class MapSerializeOptions<TFrom> : MapSerializeOptions, IMapSerializeOptions<TFrom> {
        public IMapSerializeOptions<TFrom> Ignore<TField>(Expression<Func<TFrom, TField>> from) {
            this.Ignore(MapPath.Parse(from));
            return this;
        }

        public IMapSerializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, IEnumerable<MapPath> to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            this.Map(MapPath.Parse(from), to);
            return this;
        }

        public IMapSerializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, params MapPath[] to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            return this.Map(from, to.AsEnumerable());
        }
    }
}

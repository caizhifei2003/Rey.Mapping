using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public class MapDeserializeOptions : IMapDeserializeOptions {
        private readonly List<MapPath> _ignores = new List<MapPath>();
        private readonly Dictionary<MapPath, List<MapPath>> _maps = new Dictionary<MapPath, List<MapPath>>();

        public IDictionary<string, object> Data { get; } = new Dictionary<string, object>();
        public dynamic Pack { get; } = new ExpandoObject();

        public IMapDeserializeOptions Ignore(MapPath path) {
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

        public IMapDeserializeOptions Map(MapPath from, IEnumerable<MapPath> to) {
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

        public IMapDeserializeOptions Map(MapPath from, params MapPath[] to) {
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

    public class MapDeserializeOptions<TFrom> : MapDeserializeOptions, IMapDeserializeOptions<TFrom> {
        public IMapDeserializeOptions<TFrom> Ignore<TField>(Expression<Func<TFrom, TField>> from) {
            this.Ignore(MapPath.Parse(from));
            return this;
        }

        public IMapDeserializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, IEnumerable<MapPath> to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            this.Map(MapPath.Parse(from), to);
            return this;
        }

        public IMapDeserializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, params MapPath[] to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            return this.Map(from, to.AsEnumerable());
        }
    }

    public class MapDeserializeOptions<TFrom, TTo> : MapDeserializeOptions<TFrom>, IMapDeserializeOptions<TFrom, TTo> {
        public IMapDeserializeOptions<TFrom, TTo> Map<TField>(Expression<Func<TFrom, TField>> from, IEnumerable<Expression<Func<TTo, TField>>> to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            this.Map<TField>(from, to.Select(x => MapPath.Parse(x)));
            return this;
        }

        public IMapDeserializeOptions<TFrom, TTo> Map<TField>(Expression<Func<TFrom, TField>> from, params Expression<Func<TTo, TField>>[] to) {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            return this.Map<TField>(from, to.AsEnumerable());
        }
    }
}

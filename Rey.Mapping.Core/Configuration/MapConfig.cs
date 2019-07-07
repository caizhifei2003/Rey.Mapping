using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapConfig : IMapConfig {
        private readonly List<(Type type, MapPath path)> _ignores = new List<(Type type, MapPath path)>();
        private readonly List<(Type type, MapPath path)> _fromIgnores = new List<(Type type, MapPath path)>();
        private readonly List<(Type type, MapPath path)> _toIgnores = new List<(Type type, MapPath path)>();

        public IMapConfig Ignore(Type type, MapPath path) {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            this._ignores.Add((type, path));
            return this;
        }

        public IMapConfig IgnoreFrom(Type type, MapPath path) {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            this._fromIgnores.Add((type, path));
            return this;
        }

        public IMapConfig IgnoreTo(Type type, MapPath path) {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            this._toIgnores.Add((type, path));
            return this;
        }

        public IMapConfig AttachTo(Type type, IMapSerializeOptions options) {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var paths = this._ignores
                .Where(x => x.type.Equals(type))
                .Union(this._fromIgnores.Where(x => x.type.Equals(type)))
                .Select(x => x.path);

            foreach (var path in paths) {
                options.Ignore(path);
            }

            return this;
        }

        public IMapConfig AttachTo(Type type, IMapDeserializeOptions options) {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var paths = this._ignores
                .Where(x => x.type.Equals(type))
                .Union(this._toIgnores.Where(x => x.type.Equals(type)))
                .Select(x => x.path);

            foreach (var path in paths) {
                options.Ignore(path);
            }

            return this;
        }
    }
}

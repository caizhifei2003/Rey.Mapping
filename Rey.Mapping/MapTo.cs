using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapTo : IMapTo {
        public IServiceProvider Provider { get; }
        public IMapFrom From { get; }
        public Type Type { get; }

        public MapTo(
            IServiceProvider provider,
            IMapFrom from,
            Type type) {
            this.Provider = provider;
            this.From = from;
            this.Type = type;
        }

        public object Map() {
            var toMappers = this.Provider.GetService<IEnumerable<IToMapper>>();
            var toMapper = toMappers.FirstOrDefault(x => x.Filter(this));
            if (toMapper == null)
                throw new NotImplementedException();

            var contract = this.From.MapToContract();

            return toMapper.MapToResult(this, contract);
        }
    }

    public class MapTo<T> : MapTo, IMapTo<T> {
        public MapTo(IServiceProvider provider, IMapFrom from)
            : base(provider, from, typeof(T)) {
        }
    }
}

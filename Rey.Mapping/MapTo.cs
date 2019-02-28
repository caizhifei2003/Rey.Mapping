using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapTo : IMapTo {
        public IServiceProvider Provider { get; }
        public IMapContract Contract { get; }
        public Type Type { get; }

        public MapTo(
            IServiceProvider provider,
            IMapContract contract,
            Type type) {
            this.Provider = provider;
            this.Contract = contract;
            this.Type = type;
        }

        public object Map() {
            var toMappers = this.Provider.GetService<IEnumerable<IToMapper>>();
            var toMapper = toMappers.FirstOrDefault(x => x.Filter(this));
            if (toMapper == null)
                throw new NotImplementedException();

            return toMapper.MapToResult(this, this.Contract);
        }
    }

    public class MapTo<T> : MapTo, IMapTo<T> {
        public MapTo(IServiceProvider provider, IMapContract contract)
            : base(provider, contract, typeof(T)) {
        }
    }
}

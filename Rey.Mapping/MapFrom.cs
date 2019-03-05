using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rey.Mapping {
    public class MapFrom : IMapFrom {
        public IServiceProvider Provider { get; }
        public object Value { get; }
        public Type Type { get; }

        public MapFrom(
            IServiceProvider provider,
            object value,
            Type type) {
            this.Provider = provider;
            this.Value = value;
            this.Type = type;
        }

        public IMapContract MapToContract() {
            var fromMappers = this.Provider.GetService<IEnumerable<IFromMapper>>();
            var fromMapper = fromMappers.FirstOrDefault(x => x.Filter(this));
            if (fromMapper == null)
                throw new NotImplementedException();

            var values = new MapValueTable();

            var token = fromMapper.MapToContract(this, values);
            return new MapContract(token, values);
        }

        public IMapTo To(Type type) {
            return new MapTo(this.Provider, this, type);
        }

        public IMapTo<T> To<T>() {
            return new MapTo<T>(this.Provider, this);
        }
    }

    public class MapFrom<T> : MapFrom, IMapFrom<T> {
        public MapFrom(IServiceProvider provider, T value)
            : base(provider, value, typeof(T)) {
        }
    }
}

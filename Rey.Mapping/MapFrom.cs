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

        public IMapTo To(Type type) {
            return new MapTo(this.Provider, this, type);
        }

        public IMapTo<T> To<T>() {
            return new MapTo<T>(this.Provider, this);
        }

        public IMapContract MapToContract() {
            var fromMappers = this.Provider.GetService<IEnumerable<IFromMapper>>();
            var fromMapper = fromMappers.FirstOrDefault(x => x.Filter(this));
            if (fromMapper == null)
                throw new NotImplementedException();

            return fromMapper.MapToContract(this);
        }
    }

    public class MapFrom<T> : MapFrom, IMapFrom<T> {
        public MapFrom(IServiceProvider provider, T value)
            : base(provider, value, typeof(T)) {
        }
    }

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

    public class Mapper : IMapper {
        public IServiceProvider Provider { get; }
        public IMapperOptions Options { get; }

        public Mapper(
            IServiceProvider provider,
            IMapperOptions options) {
            this.Provider = provider;
            this.Options = options;
        }

        public IMapFrom From(object value, Type type) {
            return new MapFrom(this.Provider, value, type);
        }

        public IMapFrom<T> From<T>(T value) {
            return new MapFrom<T>(this.Provider, value);
        }
    }

    public abstract class FromMapper<T> : IFromMapper {
        public virtual bool Filter(IMapFrom from) {
            return typeof(T).Equals(from.Type);
        }

        public abstract IMapContract MapToContract(IMapFrom from);
    }

    public class FromInt32Mapper : FromMapper<Int32> {
        public override IMapContract MapToContract(IMapFrom from) {
            return null;
        }
    }

    public abstract class ToMapper<T> : IToMapper {
        public virtual bool Filter(IMapTo to) {
            return typeof(T).Equals(to.Type);
        }

        public abstract object MapToResult(IMapTo to, IMapContract contract);
    }

    public class ToInt32Mapper : ToMapper<Int32> {
        public override object MapToResult(IMapTo to, IMapContract contract) {
            throw new NotImplementedException();
        }
    }

    public class ToStringMapper : ToMapper<String> {
        public override object MapToResult(IMapTo to, IMapContract contract) {
            throw new NotImplementedException();
        }
    }

    public class MapperOptions : IMapperOptions {
    }

    public class MapperBuilder : IMapperBuilder {
        private IServiceCollection Services { get; } = new ServiceCollection();
        private MapperOptions Options { get; }

        public MapperBuilder(MapperOptions options = null) {
            this.Options = options ?? new MapperOptions();
        }

        public IMapper Build() {
            this.Services.AddSingleton<IMapperOptions>(this.Options);
            this.Services.AddSingleton<IMapper, Mapper>();
            return this.Services.BuildServiceProvider().GetService<IMapper>();
        }

        public IMapperBuilder FromMapper<TFromMapper>()
            where TFromMapper : class, IFromMapper {
            this.Services.AddSingleton<IFromMapper, TFromMapper>();
            return this;
        }

        public IMapperBuilder ToMapper<TToMapper>()
            where TToMapper : class, IToMapper {
            this.Services.AddSingleton<IToMapper, TToMapper>();
            return this;
        }
    }
}

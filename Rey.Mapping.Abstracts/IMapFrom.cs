using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping {
    public interface IMapFrom {
        object Value { get; }
        Type Type { get; }
        IMapTo To(Type type);
        IMapTo<T> To<T>();
        IMapContract MapToContract();
    }

    public interface IMapFrom<T> : IMapFrom {

    }

    public interface IMapTo {
        Type Type { get; }
        object Map();
    }

    public interface IMapTo<T> : IMapTo {

    }

    public interface IMapper {
        IMapperOptions Options { get; }
        IMapFrom From(object value, Type type);
        IMapFrom<T> From<T>(T value);
    }

    public interface IFromMapper {
        bool Filter(IMapFrom from);
        IMapContract MapToContract(IMapFrom from);
    }

    public interface IToMapper {
        bool Filter(IMapTo to);
        object MapToResult(IMapTo to, IMapContract contract);
    }

    public interface IMapToken {

    }

    public interface IMapValueTable {

    }

    public interface IMapContract {
        IMapValueTable Values { get; }
        IMapToken Token { get; }
    }

    public interface IMapperOptions {
    }

    public interface IMapperBuilder {
        IMapper Build();
        IMapperBuilder FromMapper<TFromMapper>() where TFromMapper : class, IFromMapper;
        IMapperBuilder ToMapper<TToMapper>() where TToMapper : class, IToMapper;
    }
}

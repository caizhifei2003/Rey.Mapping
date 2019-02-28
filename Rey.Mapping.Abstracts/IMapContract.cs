using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public interface IMapContract {
        IMapValueTable Values { get; }
        IMapToken Token { get; }
    }

    public interface IMapToken {
        Type Type { get; }
        List<IMapToken> Children { get; }
    }

    public interface IMapMemberToken : IMapToken {
        string Name { get; }
    }

    public interface IMapValue {
        object Value { get; }
    }

    public interface IMapMemberValue : IMapValue {
        string Name { get; }
    }

    public interface IMapValueTable {
        IMapValueTable AddValue(IMapValue value);
    }
}

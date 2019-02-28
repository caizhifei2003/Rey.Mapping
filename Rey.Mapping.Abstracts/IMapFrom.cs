using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping {
    public interface IMapFrom {
        object Value { get; }
        Type Type { get; }
        IMapTo To(Type type);
        IMapTo<T> To<T>();
    }

    public interface IMapFrom<T> : IMapFrom {
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public interface IMapDeserializeOptions {
        IMapDeserializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);

        IMapDeserializeOptions Map(MapPath from, IEnumerable<MapPath> to);
        IMapDeserializeOptions Map(MapPath from, params MapPath[] to);
        IEnumerable<MapPath> GetMapPaths(MapPath path);
    }

    public interface IMapDeserializeOptions<TFrom> : IMapDeserializeOptions {
        IMapDeserializeOptions<TFrom> Ignore<TField>(Expression<Func<TFrom, TField>> from);

        IMapDeserializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, IEnumerable<MapPath> to);
        IMapDeserializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, params MapPath[] to);
    }

    public interface IMapDeserializeOptions<TFrom, TTo> : IMapDeserializeOptions<TFrom> {
        IMapDeserializeOptions<TFrom, TTo> Map<TField>(Expression<Func<TFrom, TField>> from, IEnumerable<Expression<Func<TTo, TField>>> to);
        IMapDeserializeOptions<TFrom, TTo> Map<TField>(Expression<Func<TFrom, TField>> from, params Expression<Func<TTo, TField>>[] to);
    }
}

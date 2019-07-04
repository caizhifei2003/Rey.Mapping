using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rey.Mapping {
    public interface IMapSerializeOptions {
        /// <summary>
        /// 自定义数据
        /// </summary>
        IDictionary<string, object> Data { get; }

        /// <summary>
        /// 自定义数据
        /// </summary>
        dynamic Pack { get; }

        IMapSerializeOptions Ignore(MapPath path);
        bool IsIgnore(MapPath path);

        IMapSerializeOptions Map(MapPath from, IEnumerable<MapPath> to);
        IMapSerializeOptions Map(MapPath from, params MapPath[] to);
        IEnumerable<KeyValuePair<MapPath, IEnumerable<MapPath>>> GetMaps();
    }

    public interface IMapSerializeOptions<TFrom> : IMapSerializeOptions {
        IMapSerializeOptions<TFrom> Ignore<TField>(Expression<Func<TFrom, TField>> from);

        IMapSerializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, IEnumerable<MapPath> to);
        IMapSerializeOptions<TFrom> Map<TField>(Expression<Func<TFrom, TField>> from, params MapPath[] to);
    }
}

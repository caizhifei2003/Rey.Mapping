using System.Collections.Generic;

namespace Rey.Mapping {
    public interface IMapTable : IEnumerable<KeyValuePair<MapPath, IMapToken>> {
        void AddToken(MapPath path, IMapToken token);
        IMapToken GetToken(MapPath path);
        bool ContainsPath(MapPath path);
        IEnumerable<KeyValuePair<MapPath, IMapToken>> GetChildren(MapPath path);

        /// <summary>
        /// 序列化完成之后的附加处理。
        /// </summary>
        IMapTable AfterSerialize(IMapSerializeOptions options);

        /// <summary>
        /// 反序列化开始之前的附加处理。
        /// </summary>
        IMapTable BeforeDeserialize(IMapDeserializeOptions options);
    }
}

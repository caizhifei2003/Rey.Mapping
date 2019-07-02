using System;
using System.Linq;

namespace Rey.Mapping {
    public class MapArrayConverter : IMapConverter {
        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return ArrayUtil.Check(fromType);
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            var arr = fromValue;
            var elemType = ArrayUtil.GetElementType(fromType);
            context.Table.AddToken(path, new MapArrayToken(fromType, elemType));

            if (ArrayUtil.IsEnumerable(fromType))
                arr = ArrayUtil.ToArray(elemType, arr);

            var count = ArrayUtil.GetCount(arr);
            for (var i = 0; i < count; ++i) {
                var value = ArrayUtil.GetValue(arr, i);
                context.Serialize(path.Append($"{i}"), value, elemType, options);
            }
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            if (!(token is MapArrayToken))
                return false;

            return ArrayUtil.Check(toType);
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var children = context.Table.GetChildren(path);
            var elemType = ArrayUtil.GetElementType(toType);
            var arr = Array.CreateInstance(elemType, children.Count());
            foreach (var child in children) {
                var value = context.Deserialize(child.Key, elemType, options);
                ArrayUtil.SetValue(arr, int.Parse(child.Key.LastSegment()), value);
            }

            if (ArrayUtil.IsArray(toType))
                return arr;

            return ArrayUtil.ToList(elemType, arr);
        }
    }
}

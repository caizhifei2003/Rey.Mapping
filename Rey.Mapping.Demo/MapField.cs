using System.Reflection;

namespace Rey.Mapping {
    public class MapField : MapMember {
        public FieldInfo Field { get; }
        public override string Name => this.Field.Name;

        public MapField(FieldInfo field) {
            this.Field = field;
        }

        public override MapFrom CreateMapFrom(object target) {
            return new MapFieldFrom(target, this.Field);
        }
    }

    //public abstract class MapValue {
    //    public MapTypes Type { get; }
    //    public object Value { get; }

    //    public MapValue(MapTypes type, object value) {
    //        this.Type = type;
    //        this.Value = value;
    //    }
    //}

    //public class MapStringValue : MapValue {
    //    public MapStringValue(string value)
    //        : base(MapTypes.String, value) {
    //    }
    //}

    //public class MapNumeberValue : MapValue {
    //    public MapNumeberValue(decimal value)
    //        : base(MapTypes.Number, value) {
    //    }
    //}

    //public class MapObjectValue : MapValue {
    //    public MapObjectValue(object value)
    //        : base(MapTypes.Object, value) {
    //    }
    //}

    //public class MapPath {
    //    public string Name { get; }
    //    public MapPath Parent { get; }

    //    public MapPath(string name = null, MapPath parent = null) {
    //        this.Name = name;
    //        this.Parent = parent;
    //    }
    //}

    ////public class MapNode {
    ////    public MapValue Value { get; set; }
    ////    public MapPath Path { get; set; }
    ////    public List<MapNode> Children { get; } = new List<MapNode>();
    ////}

    //public enum MapNodeTypes {
    //    String,
    //    Number,
    //    Enum,
    //    Date,
    //    Object,
    //}

    //public abstract class MapNode {
    //    public MapNodeTypes NodeType { get; }

    //    public MapNode(MapNodeTypes nodeType) {
    //        this.NodeType = nodeType;
    //    }
    //}

    //public abstract class MapValueNode : MapNode {
    //    public object Value { get; }

    //    public MapValueNode(MapNodeTypes nodeType, object value)
    //        : base(nodeType) {
    //        this.Value = value;
    //    }
    //}

    //public class MapStringValueNode : MapValueNode {
    //    public MapStringValueNode(string value)
    //        : base(MapNodeTypes.String, value) {
    //    }
    //}

    //public class MapObjectNode : MapNode {
    //    public MapObjectNode()
    //        : base(MapNodeTypes.Object) {
    //    }
    //}

    //public interface IMapFromContext {
    //    MapNode MapFrom(MapFrom from);
    //}

    //public class MapFromContext : IMapFromContext {
    //    private IDefaultFromMapper Mapper { get; }

    //    public MapFromContext(IDefaultFromMapper mapper) {
    //        this.Mapper = mapper;
    //    }

    //    public MapNode MapFrom(MapFrom from) {
    //        return this.Mapper.MapFrom(from, this);
    //    }
    //}

    //public class DefaultFromMapper : IDefaultFromMapper {
    //    private IEnumerable<IFromMapper> Mappers { get; }

    //    public DefaultFromMapper(IEnumerable<IFromMapper> mappers) {
    //        this.Mappers = mappers;
    //    }

    //    public MapNode MapFrom(MapFrom from, IMapFromContext context) {
    //        foreach (var mapper in this.Mappers) {
    //            try {
    //                return mapper.MapFrom(from, context);
    //            } catch (MapFieldException) {
    //                continue;
    //            }
    //        }
    //        throw new MapFieldException();
    //    }
    //}

    //public interface IFromMapper {
    //    MapNode MapFrom(MapFrom from, IMapFromContext context);
    //}

    //public interface IDefaultFromMapper : IFromMapper {

    //}

    //public class MapFieldException : Exception {

    //}

    //public class FromStringMapper : IFromMapper {
    //    public bool Filter(MapFrom from) {
    //        var type = from.Type.Type;
    //        return typeof(string).Equals(type)
    //            || typeof(char).Equals(type);
    //    }

    //    public MapNode MapFrom(MapFrom from, IMapFromContext context) {
    //        if (!this.Filter(from))
    //            throw new MapFieldException();

    //        var value = new MapStringValue($"{from.Value}");
    //        return new MapNode() {
    //            Value = value,
    //        };
    //    }
    //}

    //public class FromNumberMapper : IFromMapper {
    //    public bool Filter(MapFrom from) {
    //        var type = from.Type.Type;
    //        return typeof(Int16).Equals(type) || typeof(UInt16).Equals(type)
    //            || typeof(Int32).Equals(type) || typeof(UInt32).Equals(type)
    //            || typeof(Int64).Equals(type) || typeof(UInt64).Equals(type)
    //            || typeof(float).Equals(type) || typeof(double).Equals(type) || typeof(decimal).Equals(type);
    //    }

    //    public MapNode MapFrom(MapFrom from, IMapFromContext context) {
    //        if (!this.Filter(from))
    //            throw new MapFieldException();

    //        var changed = (decimal)Convert.ChangeType(from.Value, typeof(decimal));
    //        var value = new MapNumeberValue(changed);
    //        return new MapNode() {
    //            Value = value,
    //        };
    //    }
    //}

    //public class FromObjectMapper : IFromMapper {
    //    public bool Filter(MapFrom from) {
    //        var type = from.Type.Type;
    //        return type.IsClass;
    //    }

    //    public MapNode MapFrom(MapFrom from, IMapFromContext context) {
    //        if (!this.Filter(from))
    //            throw new MapFieldException();

    //        if (from.Value == null)
    //            return null;

    //        var node = new MapNode() {

    //        };

    //        var members = from.Type.GetMembers();
    //        foreach (var member in members) {
    //            var memberFrom = member.CreateMapFrom(from.Value);
    //            var childNode = context.MapFrom(memberFrom);
    //            if (childNode == null)
    //                continue;

    //            node.Children.Add(childNode);
    //        }
    //        return node;
    //    }
    //}
}

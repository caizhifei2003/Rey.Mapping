using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var model = new Person() { Name = "Kevin", Age = 32, Father = new Person { Name = "Jie", Age = 70 } };
            //var from = MapFrom.Create(model);
            //var from1 = MapFrom.Create(model, x => x.Name);
            //var from2 = MapFrom.Create(model, x => x.Age);

            //var node = MapNode.Create(model);
            var mapper = new DefaultFromMapper(new List<IFromMapper>() { new FromStringMapper(), new FromNumberMapper(), new FromObjectMapper() });
            var context = new MapFromContext(mapper);

            var from = MapFrom.Create("Hello");
            var node = mapper.MapFrom(from, context);

            var from1 = MapFrom.Create(123);
            var node1 = mapper.MapFrom(from1, context);

            var from2 = MapFrom.Create(model);
            var node2 = mapper.MapFrom(from2, context);


            //var fromMgr = new FromMapperManager(new List<IFromMapper>() { new StringFromMapper(), new ClassFromMapper(), new Int32FromMapper() });
            //var values = new MapValueTable();
            //var root = fromMgr.MapFrom(from, values);
        }
    }

    public class Person {
        public string Name { get; set; }
        public Person Father { get; set; }
        public int Age;
    }

    public enum MapTypes {
        String = 1,
        Number,
        Object,
    }

    public class MapType {
        public Type Type { get; }
        public string Name => this.Type.Name;

        public MapType(Type type) {
            this.Type = type;
        }

        public static implicit operator MapType(Type type) {
            return new MapType(type);
        }

        public IEnumerable<MapProperty> GetProperties(BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            return this.Type.GetProperties(flags).Select(x => new MapProperty(x));
        }

        public IEnumerable<MapField> GetFields(BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            return this.Type.GetFields(flags).Select(x => new MapField(x));
        }

        public IEnumerable<MapMember> GetMembers(BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            var members = new List<MapMember>();
            members.AddRange(this.GetProperties(flags));
            members.AddRange(this.GetFields(flags));
            return members;
        }
    }

    public abstract class MapMember {
        public abstract MapFrom CreateMapFrom(object target);
    }

    public class MapProperty : MapMember {
        public PropertyInfo Property { get; }

        public MapProperty(PropertyInfo property) {
            this.Property = property;
        }

        public override MapFrom CreateMapFrom(object target) {
            return new MapPropertyFrom(target, this.Property);
        }
    }

    public class MapField : MapMember {
        public FieldInfo Field { get; }

        public MapField(FieldInfo field) {
            this.Field = field;
        }

        public override MapFrom CreateMapFrom(object target) {
            return new MapFieldFrom(target, this.Field);
        }
    }

    public abstract class MapValue {
        public MapTypes Type { get; }
        public object Value { get; }

        public MapValue(MapTypes type, object value) {
            this.Type = type;
            this.Value = value;
        }
    }

    public class MapStringValue : MapValue {
        public MapStringValue(string value)
            : base(MapTypes.String, value) {
        }
    }

    public class MapNumeberValue : MapValue {
        public MapNumeberValue(decimal value)
            : base(MapTypes.Number, value) {
        }
    }

    public class MapObjectValue : MapValue {
        public MapObjectValue(object value)
            : base(MapTypes.Object, value) {
        }
    }

    public class MapPath {
        public string Name { get; }
        public MapPath Parent { get; }

        public MapPath(string name = null, MapPath parent = null) {
            this.Name = name;
            this.Parent = parent;
        }
    }

    public class MapNode {
        public MapType Type { get; set; }
        public MapValue Value { get; set; }
        public MapPath Path { get; set; }
        public List<MapNode> Children { get; } = new List<MapNode>();
    }

    public class MapObjectNode : MapNode {
        public MapObjectNode(Type type, MapValue value) {
            this.Type = type;
            this.Value = value;
            this.Path = new MapPath();
        }
    }

    public abstract class MapMemberNode : MapNode {
        public object Target { get; }

        public MapMemberNode(object target, MapPath path) {
            this.Target = target;
            this.Path = path;
        }
    }

    //public class PropertyMapNode : MemberMapNode {
    //    public PropertyInfo Property { get; }
    //    public override string Name => this.Property.Name;
    //    public override Type Type => this.Property.PropertyType;
    //    public override object Value => this.Property.GetValue(this.Target);

    //    public PropertyMapNode(object target, PropertyInfo property)
    //        : base(target, null) {
    //    }
    //}

    public interface IMapFromContext {
        MapNode MapFrom(MapFrom from);
    }

    public class MapFromContext : IMapFromContext {
        private IDefaultFromMapper Mapper { get; }

        public MapFromContext(IDefaultFromMapper mapper) {
            this.Mapper = mapper;
        }

        public MapNode MapFrom(MapFrom from) {
            return this.Mapper.MapFrom(from, this);
        }
    }

    public class DefaultFromMapper : IDefaultFromMapper {
        private IEnumerable<IFromMapper> Mappers { get; }

        public DefaultFromMapper(IEnumerable<IFromMapper> mappers) {
            this.Mappers = mappers;
        }

        public MapNode MapFrom(MapFrom from, IMapFromContext context) {
            foreach (var mapper in this.Mappers) {
                try {
                    return mapper.MapFrom(from, context);
                } catch (MapFieldException) {
                    continue;
                }
            }
            throw new MapFieldException();
        }
    }

    public interface IFromMapper {
        MapNode MapFrom(MapFrom from, IMapFromContext context);
    }

    public interface IDefaultFromMapper : IFromMapper {

    }

    public class MapFieldException : Exception {

    }

    public class FromStringMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            var type = from.Type.Type;
            return typeof(string).Equals(type)
                || typeof(char).Equals(type);
        }

        public MapNode MapFrom(MapFrom from, IMapFromContext context) {
            if (!this.Filter(from))
                throw new MapFieldException();

            var value = new MapStringValue($"{from.Value}");
            return new MapNode() {
                Type = from.Type,
                Value = value,
            };
        }
    }

    public class FromNumberMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            var type = from.Type.Type;
            return typeof(Int16).Equals(type) || typeof(UInt16).Equals(type)
                || typeof(Int32).Equals(type) || typeof(UInt32).Equals(type)
                || typeof(Int64).Equals(type) || typeof(UInt64).Equals(type)
                || typeof(float).Equals(type) || typeof(double).Equals(type) || typeof(decimal).Equals(type);
        }

        public MapNode MapFrom(MapFrom from, IMapFromContext context) {
            if (!this.Filter(from))
                throw new MapFieldException();

            var changed = (decimal)Convert.ChangeType(from.Value, typeof(decimal));
            var value = new MapNumeberValue(changed);
            return new MapNode() {
                Type = from.Type,
                Value = value,
            };
        }
    }

    public class FromObjectMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            var type = from.Type.Type;
            return type.IsClass;
        }

        public MapNode MapFrom(MapFrom from, IMapFromContext context) {
            if (!this.Filter(from))
                throw new MapFieldException();

            var node = new MapNode() {
                Type = from.Type,

            };

            var members = from.Type.GetMembers();
            foreach (var member in members) {
                var memberFrom = member.CreateMapFrom(from.Value);
                var childNode = context.MapFrom(memberFrom);
                node.Children.Add(childNode);
            }
            return node;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping.Demo {
    class Program {
        static void Main(string[] args) {
            var model = new Person() { Name = "Kevin", Age = 32, Father = new Person { Name = "Jie", Age = 70 } };
            var from = new MapFrom() { Type = typeof(Person), Value = model };
            var fromMgr = new FromMapperManager(new List<IFromMapper>() { new StringFromMapper(), new ClassFromMapper(), new Int32FromMapper() });
            var values = new MapValueTable();
            var root = fromMgr.MapFrom(from, values);
        }
    }

    public class Person {
        public string Name { get; set; }
        public Person Father { get; set; }
        public int Age { get; set; }
    }

    public interface IFromMapper {
        bool Filter(MapFrom from);
        MapNode MapFrom(MapFrom from, IMapValueTable values, IFromMapperMamager manager);
    }

    public interface IFromMapperMamager {
        MapNode MapFrom(MapFrom from, IMapValueTable values);
    }

    public interface IMapContract {

    }

    public interface IMapValueTable {
        IMapValueTable ChildrenTable(string name);
        IMapValueTable AddValue(string name, object value);
    }

    public class MapValueTable : IMapValueTable {
        public Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public virtual IMapValueTable AddValue(string name, object value) {
            this.Values.Add(name, value);
            return this;
        }

        public IMapValueTable ChildrenTable(string name) {
            return new MapChildrenTable(this, name);
        }
    }

    public class MapChildrenTable : IMapValueTable {
        public IMapValueTable Values { get; }
        public string Name { get; }

        public MapChildrenTable(IMapValueTable values, string name) {
            this.Values = values;
            this.Name = name;
        }

        public IMapValueTable AddValue(string name, object value) {
            this.Values.AddValue(string.Join('.', this.Name, name), value);
            return this;
        }

        public IMapValueTable ChildrenTable(string name) {
            return new MapChildrenTable(this.Values, string.Join('.', this.Name, name));
        }
    }

    public class MapNode {
        public string Name { get; set; }
        public Type Type { get; set; }
        public MapPath Path { get; set; }
        public List<MapNode> Children { get; set; } = new List<MapNode>();
    }

    public class MapPath {
        public string Name { get; set; }
        public MapPath Parent { get; set; }

        public MapPath CreateChild(string name) {
            return new MapPath { Name = name, Parent = this };
        }

        public override string ToString() {
            var stack = new Stack<string>();
            stack.Push(this.Name);
            for (var parent = this.Parent; parent != null; parent = parent.Parent) {
                stack.Push(parent.Name);
            }
            return string.Join(" -> ", stack);
        }
    }

    public class MapFrom {
        public Type Type { get; set; }
        public object Value { get; set; }
        public virtual string Name => this.Type.Name;
    }

    public class MapMemberFrom : MapFrom {

    }

    public class MapPropertyFrom : MapMemberFrom {
        public PropertyInfo Member { get; set; }
        public override string Name => this.Member.Name;
    }

    public class MapFieldFrom : MapMemberFrom {
        public FieldInfo Member { get; set; }
        public override string Name => this.Member.Name;
    }

    public class MapTo {
        public Type Type { get; set; }
    }

    public class MapContract : IMapContract {
        public MapValueTable Values { get; set; }
        public MapNode Root { get; set; }
    }

    public class FromMapperManager : IFromMapperMamager {
        private IEnumerable<IFromMapper> Mappers { get; }

        public FromMapperManager(IEnumerable<IFromMapper> mappers) {
            this.Mappers = mappers;
        }

        public MapNode MapFrom(MapFrom from, IMapValueTable values) {
            var mapper = this.Mappers.FirstOrDefault(x => x.Filter(from));
            return mapper.MapFrom(from, values, this);
        }
    }

    public class StringFromMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            return typeof(string).Equals(from.Type);
        }

        public MapNode MapFrom(MapFrom from, IMapValueTable values, IFromMapperMamager manager) {
            var node = new MapNode() { Name = from.Name, Type = from.Type };
            values.AddValue(from.Name, from.Value);
            return node;
        }
    }

    public class Int32FromMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            return typeof(Int32).Equals(from.Type);
        }

        public MapNode MapFrom(MapFrom from, IMapValueTable values, IFromMapperMamager manager) {
            var node = new MapNode() { Name = from.Name, Type = from.Type };
            values.AddValue(from.Name, from.Value);
            return node;
        }
    }

    public class ClassFromMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            return from.Type.IsClass;
        }

        public MapNode MapFrom(MapFrom from, IMapValueTable values, IFromMapperMamager manager) {
            var props = from.Type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanRead);

            var node = new MapNode { Name = from.Name, Type = from.Type, Path = new MapPath { Name = from.Name } };
            //values.AddValue(from.Name, from.Value);

            foreach (var prop in props) {
                var type = prop.PropertyType;
                var value = prop.GetValue(from.Value);
                if (value == null)
                    continue;

                var fromProp = new MapPropertyFrom() { Type = type, Value = value, Member = prop };
                var child = manager.MapFrom(fromProp, values.ChildrenTable(from.Name));
                child.Path = node.Path.CreateChild(child.Name);
                node.Children.Add(child);
            }

            return node;
        }
    }
}

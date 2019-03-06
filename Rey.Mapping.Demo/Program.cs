using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var father = new Person { Name = "Jie", Age = 70 };
            var model = new Person() { Name = "Kevin", Age = 32, Father = father };

            //! root: children
            //! name: name="name", value="Kevin"
            //! father: name="father", children


            //var from = MapFrom.Create(model);
            //var from1 = MapFrom.Create(model, x => x.Name);
            //var from2 = MapFrom.Create(model, x => x.Age);

            //var node = MapNode.Create(model);
            //var mapper = new DefaultFromMapper(new List<IFromMapper>() { new FromStringMapper(), new FromNumberMapper(), new FromObjectMapper() });
            //var context = new MapFromContext(mapper);

            //var from = MapFrom.Create("Hello");
            //var node = mapper.MapFrom(from, context);

            //var from1 = MapFrom.Create(123);
            //var node1 = mapper.MapFrom(from1, context);

            //var from2 = MapFrom.Create(model);
            //var node2 = mapper.MapFrom(from2, context);


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

    #region 反射

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
        public abstract string Name { get; }
    }

    public class MapField : MapMember {
        public FieldInfo Field { get; }
        public override string Name => this.Field.Name;

        public MapField(FieldInfo field) {
            this.Field = field;
        }
    }

    public class MapProperty : MapMember {
        public PropertyInfo Property { get; }
        public override string Name => this.Property.Name;

        public MapProperty(PropertyInfo property) {
            this.Property = property;
        }
    }

    #endregion 反射
}

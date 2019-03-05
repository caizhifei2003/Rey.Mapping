using System;

namespace Rey.Mapping.Demo {
    class Program {
        static void Main(string[] args) {
            var from = new MapFrom() { Type = typeof(Person), Value = new Person() { Name = "Kevin" } };

        }
    }

    public class Person {
        public string Name { get; set; }
    }

    public interface IFromMapper {
        bool Filter(MapFrom from);
        void Map(IMapValueTable values, )
    }

    public interface IToMapper {

    }

    public interface IMapValueTable {

    }

    public interface IMapNode {
        string Name { get; }
        IMapNode Children { get; }
    }

    public class MapValueTable : IMapValueTable {

    }

    public class MapNode : IMapNode {
        public string Name { get; set; }
        public IMapNode Children { get; set; }
    }

    public class MapFrom {
        public Type Type { get; set; }
        public object Value { get; set; }
    }

    public class MapTo {
        public Type Type { get; set; }
    }

    public class FromMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            throw new NotImplementedException();
        }
    }

    public class StringFromMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            return typeof(string).Equals(from.Type);
        }
    }

    public class ClassFromMapper : IFromMapper {
        public bool Filter(MapFrom from) {
            return from.Type.IsClass;
        }
    }

    public class ToMapper : IToMapper {

    }
}

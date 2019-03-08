using AutoMapper;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PersonFrom, PersonTo>());
            var mapper = config.CreateMapper();
            var from = new PersonFrom() { Name = "kevin", Father = new PersonFrom { Name = "father" } };
            from.Children.Add(new PersonFrom { Name = "child 1" });

            var to = mapper.Map<PersonTo>(from);

            var path = MapPath.Parse<PersonFrom>(x => x.Children[3].Father.Children[2].Name).PathString;

        }

        public static object CustomMapToInt32(Type type, MapPath path, MapToContext context) {
            return 999;
        }
    }

    public class PersonFrom {
        public string Name { get; set; }
        public PersonFrom Father { get; set; }
        public List<PersonFrom> Children { get; } = new List<PersonFrom>();
    }

    public class PersonTo {
        public string Name { get; set; }
        public PersonTo Father { get; set; }
        public List<PersonTo> Children { get; } = new List<PersonTo>();
    }
}

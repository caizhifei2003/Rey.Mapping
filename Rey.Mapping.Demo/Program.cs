using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var provider = new ServiceCollection().AddReyMapping().BuildServiceProvider();
            var mapper = provider.GetService<IMapper>();
            var to = mapper.From(new PersonFrom() { Gender = GenderFrom.Female }).To<PersonTo>();

        }

        public static object CustomMapToInt32(Type type, MapPath path, MapToContext context) {
            return 999;
        }
    }

    public class PersonFrom {
        public string Name { get; set; }
        public PersonFrom Father { get; set; }
        public List<PersonFrom> Children { get; set; } = new List<PersonFrom>();
        public GenderFrom Gender { get; set; }
    }

    public enum GenderFrom {
        Male,
        Female,
    }

    public enum GenderTo {
        Male,
        Female,
    }

    public class PersonTo {
        public string Name { get; set; }
        public PersonTo Father { get; set; }
        public List<PersonTo> Children { get; set; } = new List<PersonTo>();
        public GenderTo Gender { get; set; }
    }
}

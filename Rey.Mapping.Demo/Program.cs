using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            services.AddReyMapping(builder => {
                //builder.AddToMapper(typeof(Int32), CustomMapToInt32);
            });
            var provider = services.BuildServiceProvider();
            var mapper = provider.GetService<IMapper>();

            var father = new PersonFrom { Name = "Jie", Age = 70 };
            var person = new PersonFrom { Name = "Kevin", Age = 32, Father = father };

            var from1 = mapper.From<IEnumerable<PersonFrom>>(new List<PersonFrom>() { person });
            var to1 = from1.To<IEnumerable<PersonTo>>();
        }

        public static object CustomMapToInt32(Type type, MapPath path, MapToContext context) {
            return 999;
        }
    }

    public class PersonFrom {
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonFrom Father { get; set; }
    }

    public class PersonTo {
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonTo Father { get; set; }
    }

    public class PersonTo2 {
        public string Name { get; set; }
        public string Age { get; set; }
        public PersonTo Father { get; set; }
    }
}

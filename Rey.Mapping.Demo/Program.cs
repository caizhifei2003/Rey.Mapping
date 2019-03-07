using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var father = new PersonFrom { Name = "Jie", Age = 70 };
            var person = new PersonFrom { Name = "Kevin", Age = 32, Father = father };
            //! "": person
            //! "Name": "Kevin"
            //! "Age": 32
            //! "Father": father

            var fromMappers = new List<IFromMapper> {
                new FromStringMapper(),
                new FromInt32Mapper(),
                new FromClassMapper(),
                new FromCharMapper(),
            };
            var fromMapper = new AggFromMapper(fromMappers);
            var fromContext = new MapFromContext(fromMapper);
            fromMapper.MapFrom(typeof(PersonFrom), person, new MapPath(), fromContext);
            //fromMapper.MapFrom(typeof(string), "123", new MapPath(), fromContext);


            var custom1 = new CustomToMapper(typeof(Int32), (Type type, MapPath path, MapToContext context) => {
                return 999;
            });

            var toMappers = new List<IToMapper> { custom1, new ToStringMapper(), new ToInt32Mapper(), new ToClassMapper() };
            var toMapper = new AggToMapper(toMappers);
            var toContext = new MapToContext(toMapper, fromContext.Values);
            var to = toMapper.MapTo(typeof(PersonTo), new MapPath(), toContext);

            var mapper = new Mapper(fromMapper, toMapper);
            var from1 = mapper.From(person);
            var to1 = from1.To<PersonTo>();
            var to2 = from1.To<PersonTo2>();
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

    public class CustomToMapper : IToMapper {
        public Func<Type, MapPath, bool> CanFunc { get; }
        public Func<Type, MapPath, MapToContext, object> Func { get; }

        public bool CanMapTo(Type type, MapPath path) => this.CanFunc(type, path);
        public object MapTo(Type type, MapPath path, MapToContext context) => this.Func(type, path, context);

        public CustomToMapper(Func<Type, MapPath, bool> canFunc, Func<Type, MapPath, MapToContext, object> func) {
            this.CanFunc = canFunc;
            this.Func = func;
        }

        public CustomToMapper(Type type, MapPath path, Func<Type, MapPath, MapToContext, object> func)
            : this((x1, x2) => x1.Equals(type) && x2.Equals(path), func) {
        }

        public CustomToMapper(Type type, Func<Type, MapPath, MapToContext, object> func)
            : this((x1, _) => x1.Equals(type), func) {
        }

        public CustomToMapper(MapPath path, Func<Type, MapPath, MapToContext, object> func)
            : this((_, x2) => x2.Equals(path), func) {
        }

        public CustomToMapper(Func<Type, MapPath, MapToContext, object> func)
            : this("", func) {
        }
    }
}

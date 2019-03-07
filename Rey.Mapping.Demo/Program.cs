using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var father = new PersonFrom { Name = "Jie", Age = (char)70 };
            var person = new PersonFrom { Name = "Kevin", Age = (char)32, Father = father };
            //! "": person
            //! "Name": "Kevin"
            //! "Age": 32
            //! "Father": father

            var min = sbyte.MinValue;
            var max = sbyte.MaxValue;

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


            var toMappers = new List<IToMapper> { new ToStringMapper(), new ToInt32Mapper(), new ToClassMapper() };
            var toMapper = new AggToMapper(toMappers);
            var toContext = new MapToContext(toMapper, fromContext.Values);
            var to = toMapper.MapTo(typeof(PersonTo), new MapPath(), toContext);
        }
    }

    public class PersonFrom {
        public string Name { get; set; }
        public char Age { get; set; }
        public PersonFrom Father { get; set; }
    }

    public class PersonTo {
        public string Name { get; set; }
        public string Age { get; set; }
        public PersonTo Father { get; set; }
    }
}

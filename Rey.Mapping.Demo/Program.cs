using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var father = new Person { Name = "Jie", Age = 70 };
            var person = new Person { Name = "Kevin", Age = 32, Father = father };
            //! "": person
            //! "Name": "Kevin"
            //! "Age": 32
            //! "Father": father

            var fromMappers = new List<IFromMapper> { new FromStringMapper(), new FromInt32Mapper(), new FromClassMapper() };
            var fromMapper = new AggFromMapper(fromMappers);
            var fromContext = new MapFromContext(fromMapper);
            fromMapper.MapFrom(typeof(Person), person, new MapPath(), fromContext);
            //fromMapper.MapFrom(typeof(string), "123", new MapPath(), fromContext);

            var toMappers = new List<IToMapper> { new ToStringMapper(), new ToInt32Mapper(), new ToClassMapper() };
            var toMapper = new AggToMapper(toMappers);
            var toContext = new MapToContext(toMapper, fromContext.Values);
            var to = toMapper.MapTo(typeof(Person), new MapPath(), toContext);
        }
    }

    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Father { get; set; }
    }
}

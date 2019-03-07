using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

    public class MapToContext {
        public IToMapper Mapper { get; }
        public MapValueTable Values { get; }

        public MapToContext(IToMapper mapper, MapValueTable values) {
            this.Mapper = mapper;
            this.Values = values;
        }
    }

    public interface IToMapper {
        object MapTo(Type type, MapPath path, MapToContext context);
    }

    public interface IAggToMapper : IToMapper {

    }

    public class AggToMapper : IAggToMapper {
        private IEnumerable<IToMapper> Mappers { get; }

        public AggToMapper(IEnumerable<IToMapper> mappers) {
            this.Mappers = new List<IToMapper>(mappers);
        }

        public object MapTo(Type type, MapPath path, MapToContext context) {
            foreach (var mapper in this.Mappers) {
                try {
                    return mapper.MapTo(type, path, context);
                } catch (MapToFailedException) {
                    continue;
                }
            }
            throw new MapToFailedException();
        }
    }

    public class ToStringMapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!typeof(string).Equals(type))
                throw new MapToFailedException();

            return context.Values.GetValue(path)?.Value;
        }
    }

    public class ToInt32Mapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!typeof(Int32).Equals(type))
                throw new MapToFailedException();

            var value = context.Values.GetValue(path).Value;
            return Convert.ChangeType(value, typeof(Int32));
        }
    }

    public class ToClassMapper : IToMapper {
        public object MapTo(Type type, MapPath path, MapToContext context) {
            if (!type.IsClass || type.Namespace.Equals("System"))
                throw new MapToFailedException();

            var instance = Activator.CreateInstance(type);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props) {
                var propType = prop.PropertyType;
                var propValue = context.Mapper.MapTo(propType, path.Join(prop.Name), context);
                prop.SetValue(instance, propValue);
            }
            return instance;
        }
    }
}

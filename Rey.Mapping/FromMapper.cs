using Rey.Reflection;
using System;

namespace Rey.Mapping {
    public abstract class FromMapper<T> : IFromMapper {
        public virtual bool Filter(IMapFrom from) {
            return typeof(T).Equals(from.Type);
        }

        public abstract IMapToken MapToContract(IMapFrom from, IMapValueTable values, IMapToken parent = null);
    }

    public class FromInt32Mapper : FromMapper<Int32> {
        public override IMapToken MapToContract(IMapFrom from, IMapValueTable values, IMapToken parent = null) {
            var token = new MapToken(from.Type);
            parent?.Children?.Add(token);
            return token;
        }
    }

    public class FromClassMapper : IFromMapper {
        public bool Filter(IMapFrom from) {
            return from.Type.IsClass;
        }

        public IMapToken MapToContract(IMapFrom from, IMapValueTable values, IMapToken parent = null) {
            var token = new MapToken(from.Type);
            var members = from.Type.ReyGetMembers();
            foreach (var member in members) {
                var value = member.GetValue(from.Value);
            }
            return new MapToken(from.Type);
        }
    }
}

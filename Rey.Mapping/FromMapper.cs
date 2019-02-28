using System;

namespace Rey.Mapping {
    public abstract class FromMapper<T> : IFromMapper {
        public virtual bool Filter(IMapFrom from) {
            return typeof(T).Equals(from.Type);
        }

        public abstract IMapContract MapToContract(IMapFrom from);
    }

    public class FromInt32Mapper : FromMapper<Int32> {
        public override IMapContract MapToContract(IMapFrom from) {
            return null;
        }
    }
}

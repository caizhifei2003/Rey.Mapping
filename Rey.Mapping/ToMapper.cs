using System;

namespace Rey.Mapping {
    public abstract class ToMapper<T> : IToMapper {
        public virtual bool Filter(IMapTo to) {
            return typeof(T).Equals(to.Type);
        }

        public abstract object MapToResult(IMapTo to, IMapContract contract);
    }

    public class ToInt32Mapper : ToMapper<Int32> {
        public override object MapToResult(IMapTo to, IMapContract contract) {
            throw new NotImplementedException();
        }
    }

    public class ToStringMapper : ToMapper<String> {
        public override object MapToResult(IMapTo to, IMapContract contract) {
            throw new NotImplementedException();
        }
    }
}

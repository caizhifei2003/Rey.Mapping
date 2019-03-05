using System.Reflection;

namespace Rey.Reflection {
    public class ReyProperty : ReyMember {
        public PropertyInfo Member { get; }
        public override ReyType MemberType => this.Member.PropertyType;

        public ReyProperty(PropertyInfo member) {
            this.Member = member;
        }

        public static implicit operator ReyProperty(PropertyInfo member) {
            return new ReyProperty(member);
        }

        public override object GetValue(object target) {
            return this.Member.GetValue(target);
        }

        public override void SetValue(object target, object value) {
            this.Member.SetValue(target, value);
        }
    }
}

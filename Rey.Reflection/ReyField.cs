using System.Reflection;

namespace Rey.Reflection {
    public class ReyField : ReyMember {
        public FieldInfo Member { get; }
        public override ReyType MemberType => this.Member.FieldType;

        public ReyField(FieldInfo member) {
            this.Member = member;
        }

        public static implicit operator ReyField(FieldInfo member) {
            return new ReyField(member);
        }

        public override object GetValue(object target) {
            return this.Member.GetValue(target);
        }

        public override void SetValue(object target, object value) {
            this.Member.SetValue(target, value);
        }
    }
}

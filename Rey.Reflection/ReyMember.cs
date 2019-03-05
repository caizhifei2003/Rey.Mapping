namespace Rey.Reflection {
    public abstract class ReyMember {
        public string Name { get; }
        public abstract ReyType MemberType { get; }

        public abstract object GetValue(object target);
        public abstract void SetValue(object target, object value);
    }
}

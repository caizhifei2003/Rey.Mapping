using System;
using System.Reflection;

namespace Rey.Mapping {
    public class MapPropertyFrom : MapMemberFrom {
        public PropertyInfo Property { get; }
        public override MapType Type => this.Property.PropertyType;
        public override object Value => this.Property.GetValue(this.Target);

        public MapPropertyFrom(object target, PropertyInfo property)
            : base(target) {
            this.Property = property;
        }
    }
}

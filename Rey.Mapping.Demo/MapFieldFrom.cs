using System;
using System.Reflection;

namespace Rey.Mapping {
    public class MapFieldFrom : MapMemberFrom {
        public FieldInfo Field { get; }
        public override MapType Type => this.Field.FieldType;
        public override object Value => this.Field.GetValue(this.Target);

        public MapFieldFrom(object target, FieldInfo field)
            : base(target) {
            this.Field = field;
        }
    }


}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Rey.Reflection {
    public class RType {
        public TypeInfo GetTypeInfo() {
            throw new NotImplementedException();
        }
    }

    public abstract class RMember {

    }

    public abstract class RDataMember : RMember {

    }

    public class RProperty : RDataMember {
        public PropertyInfo GetPropertyInfo() {
            throw new NotImplementedException();
        }
    }

    public class RField : RDataMember {
        public FieldInfo GetFieldInfo() {
            throw new NotImplementedException();
        }
    }

    public class RMethod : RMember {
        public MethodInfo GetMethodInfo() {
            throw new NotImplementedException();
        }
    }

    public class RParameter {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rey.Reflection {
    public class ReyType {
        public Type Type { get; }

        public ReyType(Type type) {
            this.Type = type;
        }

        public static implicit operator ReyType(Type type) {
            return new ReyType(type);
        }

        public IEnumerable<ReyProperty> GetProperties(BindingFlags flags) {
            return this.Type
                .GetProperties(flags)
                .Select(x => new ReyProperty(x))
                .ToList();
        }

        public IEnumerable<ReyProperty> GetProperties() {
            return this.Type
                .GetProperties()
                .Select(x => new ReyProperty(x))
                .ToList();
        }

        public IEnumerable<ReyField> GetFields(BindingFlags flags) {
            return this.Type
                .GetFields(flags)
                .Select(x => new ReyField(x))
                .ToList();
        }

        public IEnumerable<ReyField> GetFields() {
            return this.Type
                .GetFields()
                .Select(x => new ReyField(x))
                .ToList();
        }

        public IEnumerable<ReyMember> GetMembers(BindingFlags flags) {
            return new List<ReyMember>()
                .Union(this.GetProperties(flags))
                .Union(this.GetFields(flags))
                .ToList();
        }

        public IEnumerable<ReyMember> GetMembers() {
            return new List<ReyMember>()
                .Union(this.GetProperties())
                .Union(this.GetFields())
                .ToList();
        }
    }
}

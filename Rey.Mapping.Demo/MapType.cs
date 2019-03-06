using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    public class MapType {
        public Type Type { get; }
        public string Name => this.Type.Name;

        public MapType(Type type) {
            this.Type = type;
        }

        public static implicit operator MapType(Type type) {
            return new MapType(type);
        }

        public IEnumerable<MapProperty> GetProperties(BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            return this.Type.GetProperties(flags).Select(x => new MapProperty(x));
        }

        public IEnumerable<MapField> GetFields(BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            return this.Type.GetFields(flags).Select(x => new MapField(x));
        }

        public IEnumerable<MapMember> GetMembers(BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
            var members = new List<MapMember>();
            members.AddRange(this.GetProperties(flags));
            members.AddRange(this.GetFields(flags));
            return members;
        }
    }
}

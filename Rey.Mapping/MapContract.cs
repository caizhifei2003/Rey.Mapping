using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    public class MapContract : IMapContract {
        public IMapToken Token { get; }
        public IMapValueTable Values { get; }

        public MapContract(IMapToken token, IMapValueTable values) {
            this.Token = token;
            this.Values = values;
        }
    }

    public class MapValue : IMapValue {
        public object Value { get; }

        public MapValue(object value) {
            this.Value = value;
        }
    }

    public class MapMemberValue : MapValue, IMapMemberValue {
        public string Name { get; }

        public MapMemberValue(object value, string name)
            : base(value) {
            this.Name = name;
        }
    }

    public class MapValueTable : IMapValueTable {
        public List<IMapValue> Items { get; } = new List<IMapValue>();

        public IMapValueTable AddValue(IMapValue value) {
            this.Items.Add(value);
            return this;
        }
    }

    public class MapToken : IMapToken {
        public Type Type { get; }
        public List<IMapToken> Children { get; } = new List<IMapToken>();

        public MapToken(Type type) {
            this.Type = type;
        }
    }

    public class MapMemberToken : MapToken, IMapMemberToken {
        public string Name { get; }

        public MapMemberToken(Type type, string name)
            : base(type) {
            this.Name = name;
        }
    }
}

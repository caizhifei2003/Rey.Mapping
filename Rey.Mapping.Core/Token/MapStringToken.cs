﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapStringToken : MapValueToken<string> {
        public static readonly IEnumerable<Type> COMP_TYPES = new List<Type> {
            typeof(string), typeof(DateTime), typeof(TimeSpan)
        };

        public MapStringToken(string value)
            : base(value, typeof(string)) {
        }

        public override bool Compatible(Type type) {
            return COMP_TYPES.Any(x => x.Equals(type));
        }

        public override object GetValue(Type type) {
            if (type.Equals<string>())
                return this.Value;

            if (type.Equals<DateTime>())
                return DateTime.Parse(this.Value);

            if (type.Equals<TimeSpan>())
                return TimeSpan.Parse(this.Value);

            throw new NotImplementedException();
        }
    }
}

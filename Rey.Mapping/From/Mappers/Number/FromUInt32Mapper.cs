﻿using System;

namespace Rey.Mapping {
    public class FromUInt32Mapper : IFromMapper {
        public bool CanMapFrom(Type type, MapPath path) {
            return typeof(UInt32).Equals(type);
        }

        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            context.Values.AddValue(path, new MapUInt32Value((UInt32)value));
        }
    }
}

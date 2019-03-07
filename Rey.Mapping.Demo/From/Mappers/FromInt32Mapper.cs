﻿using System;

namespace Rey.Mapping {
    public class FromInt32Mapper : IFromMapper {
        public void MapFrom(Type type, object value, MapPath path, MapFromContext context) {
            if (!typeof(Int32).Equals(type))
                throw new MapFromFailedException();

            throw new NotImplementedException();
        }
    }
}

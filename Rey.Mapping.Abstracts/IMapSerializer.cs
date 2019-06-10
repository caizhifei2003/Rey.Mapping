﻿using Rey.Mapping.Configuration;
using System;

namespace Rey.Mapping {
    public interface IMapSerializer {
        IMapNode Serialize(object fromValue, Type fromType, IMapSerializeOptions options);
    }
}

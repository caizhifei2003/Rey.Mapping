﻿using System;

namespace Rey.Mapping {
    public interface IMapSerializer {
        void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context);
    }
}

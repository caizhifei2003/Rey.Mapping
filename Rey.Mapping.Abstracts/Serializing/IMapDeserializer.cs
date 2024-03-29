﻿using System;

namespace Rey.Mapping {
    public interface IMapDeserializer {
        object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context);
    }
}

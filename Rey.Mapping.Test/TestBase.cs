using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping.Test {
    public abstract class TestBase {
        protected IMapper Mapper { get; } = new MapperBuilder().Build();
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Rey.Mapping.Test {
    public abstract class TestBase {
        protected IServiceProvider Provider { get; } = new ServiceCollection().AddReyMapping().BuildServiceProvider();
        protected IMapper Mapper => this.Provider.GetService<IMapper>();
    }
}

namespace Rey.Mapping.Test {
    public abstract class TestBase {
        protected IMapper Mapper { get; } = new MapperBuilder().Build();
    }
}

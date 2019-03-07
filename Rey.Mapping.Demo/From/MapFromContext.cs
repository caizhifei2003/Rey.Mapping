namespace Rey.Mapping {
    public class MapFromContext {
        public IFromMapper Mapper { get; }
        public MapValueTable Values { get; } = new MapValueTable();

        public MapFromContext(IFromMapper mapper) {
            this.Mapper = mapper;
        }
    }
}

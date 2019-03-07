namespace Rey.Mapping {
    public class MapFromContext {
        public IAggFromMapper Mapper { get; }
        public MapValueTable Values { get; } = new MapValueTable();

        public MapFromContext(IAggFromMapper mapper) {
            this.Mapper = mapper;
        }
    }
}

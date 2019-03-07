namespace Rey.Mapping {
    public class MapToContext {
        public IToMapper Mapper { get; }
        public MapValueTable Values { get; }

        public MapToContext(IToMapper mapper, MapValueTable values) {
            this.Mapper = mapper;
            this.Values = values;
        }
    }
}

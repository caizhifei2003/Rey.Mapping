namespace Rey.Mapping {
    public class MapToContext {
        public IAggToMapper Mapper { get; }
        public MapValueTable Values { get; }

        public MapToContext(IAggToMapper mapper, MapValueTable values) {
            this.Mapper = mapper;
            this.Values = values;
        }
    }
}

namespace Rey.Mapping {
    public abstract class MapMemberFrom : MapFrom {
        protected object Target { get; }

        public MapMemberFrom(object target) {
            this.Target = target;
        }
    }
}

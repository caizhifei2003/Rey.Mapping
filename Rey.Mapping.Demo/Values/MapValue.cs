namespace Rey.Mapping {
    public abstract class MapValue {
        public virtual bool IsNull => false;
        public virtual bool IsObject => false;
        public abstract object GetValue();
    }
}

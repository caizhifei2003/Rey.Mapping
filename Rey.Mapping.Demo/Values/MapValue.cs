namespace Rey.Mapping {
    public abstract class MapValue {
        public MapValueType ValueType { get; }
        public bool IsNull => this.ValueType == MapValueType.Null;
        public bool IsObject => this.ValueType == MapValueType.Object;
        public bool IsChar => this.ValueType == MapValueType.Char;
        public bool IsString => this.ValueType == MapValueType.String;
        public bool IsNumber => this.ValueType >= MapValueType.Int8 && this.ValueType <= MapValueType.Decimal;
        public bool IsIntNumber => this.ValueType >= MapValueType.Int8 && this.ValueType <= MapValueType.Int64;
        public bool IsUIntNumber => this.ValueType >= MapValueType.UInt8 && this.ValueType <= MapValueType.UInt64;
        public bool IsFloatNumber => this.ValueType >= MapValueType.Float && this.ValueType <= MapValueType.Decimal;

        public MapValue(MapValueType valueType) {
            this.ValueType = valueType;
        }

        public abstract object GetValue();
    }

    public abstract class MapNumberValue : MapValue {
        public MapNumberValue(MapValueType valueType)
            : base(valueType) {
        }
    }
}

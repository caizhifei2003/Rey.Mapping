using System;
using System.Collections.Generic;
using System.Linq;

namespace Rey.Mapping {
    public class MapNumberConverter : IMapConverter {
        private static readonly IEnumerable<Type> TYPES_FLOAT = new List<Type>() {
            typeof(Single),
            typeof(Double),
            typeof(Decimal)
        };

        private static readonly IEnumerable<Type> TYPES_SIGNED = new List<Type>() {
            typeof(SByte),
            typeof(Int16),
            typeof(Int32),
            typeof(Int64)
        };

        private static readonly IEnumerable<Type> TYPES_UNSIGNED = new List<Type>() {
            typeof(Byte),
            typeof(UInt16),
            typeof(UInt32),
            typeof(UInt64)
        };

        private static readonly IEnumerable<Type> TYPES = TYPES_FLOAT
            .Union(TYPES_SIGNED)
            .Union(TYPES_UNSIGNED);

        public bool CanSerialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            return TYPES.Any(x => x.Equals(fromType));
        }

        public void Serialize(MapPath path, object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            if (fromType.Equals<Single>()) {
                context.Table.AddToken(path, new MapSingleToken((Single)fromValue));
                return;
            }

            if (fromType.Equals<Double>()) {
                context.Table.AddToken(path, new MapDoubleToken((Double)fromValue));
                return;
            }

            if (fromType.Equals<Decimal>()) {
                context.Table.AddToken(path, new MapDecimalToken((Decimal)fromValue));
                return;
            }

            if (fromType.Equals<SByte>()) {
                context.Table.AddToken(path, new MapInt8Token((SByte)fromValue));
                return;
            }

            if (fromType.Equals<Int16>()) {
                context.Table.AddToken(path, new MapInt16Token((Int16)fromValue));
                return;
            }

            if (fromType.Equals<Int32>()) {
                context.Table.AddToken(path, new MapInt32Token((Int32)fromValue));
                return;
            }

            if (fromType.Equals<Int64>()) {
                context.Table.AddToken(path, new MapInt64Token((Int64)fromValue));
                return;
            }

            if (fromType.Equals<Byte>()) {
                context.Table.AddToken(path, new MapUInt8Token((Byte)fromValue));
                return;
            }

            if (fromType.Equals<UInt16>()) {
                context.Table.AddToken(path, new MapUInt16Token((UInt16)fromValue));
                return;
            }

            if (fromType.Equals<UInt32>()) {
                context.Table.AddToken(path, new MapUInt32Token((UInt32)fromValue));
                return;
            }

            if (fromType.Equals<UInt64>()) {
                context.Table.AddToken(path, new MapUInt64Token((UInt64)fromValue));
                return;
            }

            throw new NotImplementedException();
        }

        public bool CanDeserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            if (!token.IsNumber)
                return false;

            return token.Compatible(toType);
        }

        public object Deserialize(MapPath path, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var token = context.Table.GetToken(path);
            return token.GetValue(toType);
        }

        //    public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
        //        return token is IMapValueToken value && value.Compatible(toType);
        //    }

        //    public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
        //        return TYPES.Any(x => x.Equals(fromType));
        //    }

        //    public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
        //        return (token as IMapValueToken).GetValue(toType);
        //    }

        //    public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
        //        if (fromType.Equals(typeof(Single)))
        //            return new MapSingleToken((Single)fromValue, fromType);

        //        if (fromType.Equals(typeof(Double)))
        //            return new MapDoubleToken((Double)fromValue, fromType);

        //        if (fromType.Equals(typeof(Decimal)))
        //            return new MapDecimalToken((Decimal)fromValue, fromType);

        //        if (fromType.Equals(typeof(SByte)))
        //            return new MapInt8Token((SByte)fromValue, fromType);

        //        if (fromType.Equals(typeof(Int16)))
        //            return new MapInt16Token((Int16)fromValue, fromType);

        //        if (fromType.Equals(typeof(Int32)))
        //            return new MapInt32Token((Int32)fromValue, fromType);

        //        if (fromType.Equals(typeof(Int64)))
        //            return new MapInt64Token((Int64)fromValue, fromType);

        //        if (fromType.Equals(typeof(Byte)))
        //            return new MapUInt8Token((Byte)fromValue, fromType);

        //        if (fromType.Equals(typeof(UInt16)))
        //            return new MapUInt16Token((UInt16)fromValue, fromType);

        //        if (fromType.Equals(typeof(UInt32)))
        //            return new MapUInt32Token((UInt32)fromValue, fromType);

        //        if (fromType.Equals(typeof(UInt64)))
        //            return new MapUInt64Token((UInt64)fromValue, fromType);

        //        throw new NotImplementedException();
        //    }
    }
}

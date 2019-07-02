using Rey.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rey.Mapping {
    public class MapArrayConverter : IMapConverter {
        public bool CanDeserialize(IMapToken token, Type toType, IMapDeserializeOptions options) {
            return token is MapArrayToken && (ArrayUtil.IsArray(toType) || EnumerableUtil.IsEnumerable(toType));
        }

        public bool CanSerialize(object fromValue, Type fromType, IMapSerializeOptions options) {
            return ArrayUtil.IsArray(fromType) || EnumerableUtil.IsEnumerable(fromType);
        }

        public object Deserialize(IMapToken token, Type toType, IMapDeserializeOptions options, IMapDeserializeContext context) {
            var tokens = (token as MapArrayToken).Tokens.ToList();
            if (ArrayUtil.IsArray(toType)) {
                var elemType = ArrayUtil.GetElementType(toType);
                var arr = ArrayUtil.CreateInstance(elemType, tokens.Count);
                for (var i = 0; i < tokens.Count; ++i) {
                    var value = context.Deserialize(tokens[i], elemType, options);
                    ArrayUtil.SetValue(toType, arr, i, value);
                }
                return arr;
            }

            if (EnumerableUtil.IsEnumerable(toType)) {
                var elemType = EnumerableUtil.GetElementType(toType);
                var arr = ArrayUtil.CreateInstance(elemType, tokens.Count);
                for (var i = 0; i < tokens.Count; ++i) {
                    var value = context.Deserialize(tokens[i], elemType, options);
                    ArrayUtil.SetValue(arr.GetType(), arr, i, value);
                }
                return EnumerableUtil.ToList(elemType, arr);
            }

            throw new NotImplementedException();
        }

        public IMapToken Serialize(object fromValue, Type fromType, IMapSerializeOptions options, IMapSerializeContext context) {
            if (ArrayUtil.IsArray(fromType)) {
                var count = ArrayUtil.GetCount(fromType, fromValue);
                var elemType = ArrayUtil.GetElementType(fromType);
                var tokens = new List<IMapToken>();
                for (var i = 0; i < count; ++i) {
                    var value = ArrayUtil.GetValue(fromType, fromValue, i);
                    var token = context.Serialize(value, elemType, options);
                    tokens.Add(token);
                }
                return new MapArrayToken(tokens);
            }

            if (EnumerableUtil.IsEnumerable(fromType)) {
                var elemType = EnumerableUtil.GetElementType(fromType);
                var count = EnumerableUtil.GetCount(elemType, fromValue);
                var arr = EnumerableUtil.ToArray(elemType, fromValue);
                var tokens = new List<IMapToken>();
                for (var i = 0; i < count; ++i) {
                    var value = ArrayUtil.GetValue(arr.GetType(), arr, i);
                    var token = context.Serialize(value, elemType, options);
                    tokens.Add(token);
                }
                return new MapArrayToken(tokens);
            }

            throw new NotImplementedException();
        }
    }

    internal static class ArrayUtil {
        public static bool IsArray(Type type) {
            return type.IsArray;
        }

        public static Type GetElementType(Type type) {
            return type.GetElementType();
        }

        public static int GetCount(Type type, object value) {
            return (int)type.GetProperty("Length").GetValue(value);
        }

        public static object CreateInstance(Type elemType, int count) {
            return Array.CreateInstance(elemType, count);
        }

        public static object GetValue(Type type, object arr, int index) {
            var mGet = type.GetMethod("Get", BindingFlags.Public | BindingFlags.Instance);
            return mGet.Invoke(arr, new object[] { index });
        }

        public static void SetValue(Type type, object arr, int index, object value) {
            var mSet = type.GetMethod("Set", BindingFlags.Public | BindingFlags.Instance);
            mSet.Invoke(arr, new object[] { index, value });
        }
    }

    internal static class EnumerableUtil {
        public static Type GetEnumerableType(Type type) {
            if (type.IsGenericType && typeof(IEnumerable<>).Equals(type.GetGenericTypeDefinition()))
                return type;

            return type.GetInterfaces().FirstOrDefault(x => {
                if (!x.IsGenericType) return false;
                if (!typeof(IEnumerable<>).Equals(x.GetGenericTypeDefinition())) return false;
                return true;
            });
        }

        public static bool IsEnumerable(Type type) {
            return GetEnumerableType(type) != null;
        }

        public static Type GetElementType(Type type) {
            return GetEnumerableType(type)?.GetGenericArguments()[0];
        }

        public static int GetCount(Type elemType, object value) {
            var mCount = typeof(Enumerable).GetMethods().FirstOrDefault(x => {
                if (!x.Name.Equals("Count")) return false;
                if (x.GetParameters().Length != 1) return false;
                return true;
            });

            mCount = mCount.MakeGenericMethod(elemType);

            return (int)mCount.Invoke(null, new object[] { value });
        }

        public static object ToArray(Type elemType, object value) {
            return typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(elemType).Invoke(null, new object[] { value });
        }

        public static object ToList(Type elemType, object value) {
            return typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(elemType).Invoke(null, new object[] { value });
        }
    }
}

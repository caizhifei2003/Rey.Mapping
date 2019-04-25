using Rey.Mapping.Configuration;
using Rey.Mapping.Models;
using System;
using System.Collections.Generic;

namespace Rey.Mapping {
    class Program {
        static void Main(string[] args) {
            var mapper = new MappingBuilder().Build();
            var to = mapper.From(new List<PersonFrom> { new PersonFrom() { Gender = GenderFrom.Female } }).To<List<PersonTo>>();

        }

        public static object CustomMapToInt32(Type type, MapPath path, MapToContext context) {
            return 999;
        }
    }
}

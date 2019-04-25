using System;
using System.Collections.Generic;
using System.Text;

namespace Rey.Mapping.Models {
    public class PersonFrom {
        public string Name { get; set; }
        public PersonFrom Father { get; set; }
        public List<PersonFrom> Children { get; set; } = new List<PersonFrom>();
        public GenderFrom Gender { get; set; }
    }
}

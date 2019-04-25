using System.Collections.Generic;

namespace Rey.Mapping.Models {
    public class PersonTo {
        public string Name { get; set; }
        public PersonTo Father { get; set; }
        public List<PersonTo> Children { get; set; } = new List<PersonTo>();
        public GenderTo Gender { get; set; }
    }
}

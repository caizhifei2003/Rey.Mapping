using System.Collections.Generic;

namespace Rey.Mapping.Test.Models {
    public class PersonFrom {
        public string Name { get; set; }
        public PersonFrom Parent { get; set; }
        public List<PersonFrom> Children { get; set; }
    }
}

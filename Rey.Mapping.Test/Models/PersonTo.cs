namespace Rey.Mapping.Test.Models {
    public class PersonTo {
        public string Name { get; set; }
        public PersonTo Parent { get; set; }
        public PersonTo[] Children { get; set; }
    }
}

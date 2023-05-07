namespace EpiConnectAPI.Core.Model {
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string? ImgPath { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}

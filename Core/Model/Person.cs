using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EpiConnectAPI.Core.Model {
    public abstract class Person {

        public int PersonId { get; set; }
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

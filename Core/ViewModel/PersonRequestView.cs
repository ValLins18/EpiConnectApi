using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Core.ViewModel {
    public class PersonRequestView {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string? ImgPath { get; set; }
        public virtual PhoneRequestView Phone { get; set; }
        public virtual AddressRequestView Address { get; set; }
    }
}

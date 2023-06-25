using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Core.ViewModel {
    public class EmployeeLeaderView {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public Post Post { get; set; }
    }
}

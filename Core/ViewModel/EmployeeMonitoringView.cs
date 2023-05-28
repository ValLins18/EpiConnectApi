using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Core.ViewModel {
    public class EmployeeMonitoringView {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public Post Post { get; set; }
        public bool IsOpenAlert { get; set; } = false;
    }
}

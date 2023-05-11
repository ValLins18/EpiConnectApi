using EpiConnectAPI.Core.Enums;

namespace EpiConnectAPI.Core.Model {
    public class Epi {
        public int EpiId { get; set; }
        public string Name { get; set; }
        public ProtectionType ProtectionType { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public IEnumerable<Alert>? Alerts { get; set; }

        public int? MetricsId { get; set; }
        public virtual Metrics Metrics { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee{ get; set; }
    }
}

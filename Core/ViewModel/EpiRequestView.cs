using EpiConnectAPI.Core.Enums;

namespace EpiConnectAPI.Core.ViewModel {
    public class EpiRequestView {
        public string Name { get; set; }
        public ProtectionType ProtectionType { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}

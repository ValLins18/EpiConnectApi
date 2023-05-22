using EpiConnectAPI.Core.Enums;
using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Core.ViewModel {
    public class AlertRequestView {
        public MetricsRequestView Metrics { get; set; }
        public int EpiId { get; set; }
    }
}

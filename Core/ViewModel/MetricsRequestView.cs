namespace EpiConnectAPI.Core.ViewModel {
    public class MetricsRequestView {
        public int BatteryLevel { get; set; }
        public int? Noise { get; set; }
        public bool IsProtected { get; set; }
        public bool IsContingency { get; set; } = false;
    }
}

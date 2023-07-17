namespace EpiConnectAPI.Core.ViewModel {
    public class MetricsRequestView {
        public int BatteryLevel { get; set; }
        public decimal? Noise { get; set; }
        public bool IsProtected { get; set; }
        public bool IsContingency { get; set; } = false;
    }
}

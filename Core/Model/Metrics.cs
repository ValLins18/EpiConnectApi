namespace EpiConnectAPI.Core.Model {
    public class Metrics {
        public int MetricsId { get; set; }
        public int BatteryLevel { get; set; }
        public int? Noise{ get; set; }
        public bool IsProtected { get; set; }
        public bool IsContingency { get; set; } = false;
    }
}

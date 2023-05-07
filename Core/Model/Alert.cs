using EpiConnectAPI.Core.Enums;

namespace EpiConnectAPI.Core.Model {
    public class Alert {
        public long AlertId { get; set; }
        public DangerousLevel DangerousLevel{ get; set; }

        public int MetricsId { get; set; }
        public virtual Metrics Metrics { get; set; }
        public int EpiId { get; set; }
        public virtual Epi Epi { get; set; }
    }
}
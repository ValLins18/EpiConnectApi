using EpiConnectAPI.Core.Enums;
using System.Text.Json.Serialization;

namespace EpiConnectAPI.Core.Model {
    public class Alert {
        public int AlertId { get; set; }
        public DangerousLevel DangerousLevel{ get; set; }
        public DateTime AlertDate { get; set; }

        public int MetricsId { get; set; }
        public virtual Metrics Metrics { get; set; }
        public int EpiId { get; set; }
        [JsonIgnore]
        public virtual Epi Epi { get; set; }
    }
}
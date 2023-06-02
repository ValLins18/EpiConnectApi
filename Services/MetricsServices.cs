using EpiConnectAPI.Core;
using EpiConnectAPI.Core.Model;
using Microsoft.AspNetCore.SignalR;

namespace EpiConnectAPI.Services {
    public class MetricsServices {
        private readonly IHubContext _hubContext;

        public MetricsServices(IHubContext hubContext) {
            _hubContext = hubContext;
        }

        public async Task SendMetricsToClient(Metrics metrics) {
            await _hubContext.Clients.All.SendAsync("ReceiveMetrics", metrics);
        }
    }
}

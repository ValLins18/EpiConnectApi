using EpiConnectAPI.Core.Model;
using Microsoft.AspNetCore.SignalR;

namespace EpiConnectAPI.Core {
    public class WebSocketHub1 : Hub {
        public override async Task OnConnectedAsync() {

            while(true) {
                var randomNumber = new Random().Next(1, 100);

                var metrics = new Metrics {
                    MetricsId = 1,
                    BatteryLevel = 80,
                    Noise = randomNumber,
                    IsProtected = true,
                    IsContingency = false
                };

                await Clients.All.SendAsync("ReceiveMetrics", metrics);
                await Task.Delay(1000);
            }

        }
        
    }

    public class WebSocketHub2 : Hub {
        public override async Task OnConnectedAsync() {

            while (true) {
                var randomNumber = new Random().Next(1, 100);

                var metrics = new Metrics {
                    MetricsId = 2,
                    BatteryLevel = 100,
                    Noise = randomNumber,
                    IsProtected = (randomNumber < 70),
                    IsContingency = false
                };

                await Clients.All.SendAsync("ReceiveMetrics", metrics);
                await Task.Delay(1000);
            }

        }

    }

    public class WebSocketHub3 : Hub {
        public override async Task OnConnectedAsync() {

            while (true) {
                var randomNumber = new Random().Next(1, 100);

                var metrics = new Metrics {
                    MetricsId = 3,
                    BatteryLevel = 20,
                    Noise = randomNumber,
                    IsProtected = (randomNumber < 70),
                    IsContingency = true
                };

                await Clients.All.SendAsync("ReceiveMetrics", metrics);
                await Task.Delay(1000);
            }

        }

    }
}

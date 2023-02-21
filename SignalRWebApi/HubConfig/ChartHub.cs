using Microsoft.AspNetCore.SignalR;
using SignalRWebApi.Models;

namespace SignalRWebApi.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}

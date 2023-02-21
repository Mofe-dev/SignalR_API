using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRWebApi.DataStorage;
using SignalRWebApi.HubConfig;
using SignalRWebApi.TimerFeatures;

namespace SignalRWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        [HttpGet(Name = "GetTransferRandom")]
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}

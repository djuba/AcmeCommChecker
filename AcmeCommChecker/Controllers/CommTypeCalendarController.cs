using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeCommChecker.Factories;
using AcmeCommChecker.Models;
using AcmeCommChecker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AcmeCommChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommTypeCalendarController : ControllerBase
    {
        private readonly ILogger<CommTypeCalendarController> _logger;
        private readonly IConfiguration Configuration;

        public CommTypeCalendarController(ILogger<CommTypeCalendarController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<CommTypeCalendarEvent>> Get(string location)
        {
            var forecast = await new OpenWeatherSerivce(Configuration).GetForecast(location);

            //var events = new List<CommTypeCalendarEvent> { new CommTypeCalendarEvent { Start = DateTime.Now, Title = "Test Event" } };
            var events = new CommTypeCalendarEventFactory().GetCommTypeCalendarEvents(forecast);

            return events;
        }
    }
}

using AcmeCommChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCommChecker.Factories
{
    public class CommTypeCalendarEventFactory
    {
        const string Phone = "phone";
        const string Email = "email";
        const string SMS = "sms";

        public List<CommTypeCalendarEvent> GetCommTypeCalendarEvents(OpenWeatherForecast forecast)
        {
            var events = new List<CommTypeCalendarEvent>();

            if (forecast.list != null)
            {
                foreach (var projection in forecast.list)
                {
                    var commTypeName = GetCommType(projection);

                    var commTypeCalendarEvent = new CommTypeCalendarEvent
                    {
                        StartUtc = projection.dt_txt,
                        EndUtc = projection.dt_txt.AddHours(3),
                        CssClasses = $"commType commType-{commTypeName}",
                        Temp = projection.main.temp,
                        WeatherId = projection.weather[0].id,
                        CommTypeName = commTypeName
                    };

                    events.Add(commTypeCalendarEvent);
                }

                events.OrderBy(x => x.StartUtc);
            }

            return events;
        }

        public string GetCommType(OpenWeatherForecast.Projection projection)
        {
            var commType = CommTypeCalendarEvent.CommType.SMS.ToString();
            if (projection.main.temp < 55 || (projection.rain?._3h ?? 0) > 0)
            {
                commType = CommTypeCalendarEvent.CommType.Phone.ToString();
            }
            else if (projection.main.temp < 75)
            {
                commType = CommTypeCalendarEvent.CommType.Email.ToString();
            }

            return commType;
        }
    }
}

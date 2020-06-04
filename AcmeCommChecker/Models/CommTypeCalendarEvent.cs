using System;

namespace AcmeCommChecker.Models
{
    public class CommTypeCalendarEvent
    {
        public DateTime StartUtc { get; set; }

        public DateTime EndUtc { get; set; }

        public string CssClasses { get; set; }

        public float Temp { get; set; }

        public int WeatherId { get; set; }

        public string CommTypeName { get; set; }

        public enum CommType
        {
            Phone,
            Email,
            SMS
        }
    }
}

using System;

namespace Msi.UtilityKit
{
    public static class DateTimeUtilities
    {

        private const string _isoFormatter = "yyyy-MM-ddTHH:mm:ss.FFFFFFFZ";

        public static string ToIsoFormat(this DateTime dateTime)
        {
            return dateTime.ToString(_isoFormatter);
        }

        public static int ToUtcHour(this int localHour, int timeZoneOffset)
        {
            var today = DateTime.UtcNow.Date;
            var runHourDate = new DateTime(today.Year, today.Month, today.Day, localHour, 0, 0);
            var offsetDay = runHourDate.AddHours(timeZoneOffset);
            return offsetDay.Hour;
        }

        public static string IsoToReadableDate(string isoDatetime)
        {
            try
            {
                var datetimeStr = DateTime.Parse(isoDatetime).ToString("d/MM/yyyy h:mm:ss tt");
                return datetimeStr;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}

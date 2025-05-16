using System.Security.Cryptography;

namespace WebApi8_Scheduling.Models
{
    public class DayWithTimesModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public string DayOfWeekName { get; set; }
        public int DayId { get; set; }

        public DayWithTimesModel(DateTime day)
        {
            Day = day.Date.Day;
            Month = day.Date.Month;
            DayOfWeekName = GetPortugueseDayOfWeek(day);
            DayId = (int)day.DayOfWeek;
        }

        private string GetPortugueseDayOfWeek(DateTime date)
        {
            var dayOfWeek = date.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
            return char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
        }
    }
}

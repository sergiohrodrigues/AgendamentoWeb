using System.Security.Cryptography;

namespace WebApi8_Scheduling.Models
{
    public class DayWithTimesModel
    {
        public DateTime Day { get; set; }
        public string DayOfWeekName { get; set; }
        public List<string> Times { get; set; }

        public DayWithTimesModel(DateTime day, int timeStart = 8, int timeEnd = 20)
        {
            Day = day.Date;
            DayOfWeekName = GetPortugueseDayOfWeek(day);
            Times = new List<string>();

            for (int hora = timeStart; hora <= timeEnd; hora++)
            {
                Times.Add(new TimeSpan(hora, 0, 0).ToString(@"hh\:mm"));
            }
        }

        private string GetPortugueseDayOfWeek(DateTime date)
        {
            var dayOfWeek = date.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
            return char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
        }
    }
}

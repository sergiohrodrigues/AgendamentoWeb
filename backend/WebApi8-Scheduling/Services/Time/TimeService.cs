using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Time
{
    public class TimeService : ITimeService
    {
        public List<DayWithTimesModel> GenerateSchedulesOfTheYear()
                 {
                     var daysWithTimes = new List<DayWithTimesModel>();
                     var startDate = DateTime.Today;
                     var endDate = new DateTime(startDate.Year, 12, 31);
         
                     for (var data = startDate; data <= endDate; data = data.AddDays(1))
                     {
                         if (data.DayOfWeek == DayOfWeek.Sunday)
                             continue;
         
                         daysWithTimes.Add(new DayWithTimesModel(data));
                     }
         
                     return daysWithTimes;
                 }

        // public void RemoveDay(ref List<DayWithTimesModel> days, DateTime dayToRemove)
        // {
        //     days.RemoveAll(d => d.Day.Date == dayToRemove.Date);
        // }

        //public void RemoveTimeFromDay(ref List<DayWithTimesModel> days, DateTime day, TimeSpan timeToRemove)
        //{
        //    var dayEntry = days.FirstOrDefault(d => d.Day.Date == day.Date);

        //    if (dayEntry != null)
        //    {
        //        dayEntry.Times.RemoveAll(h => h.TimeOfDay == timeToRemove);
        //    }
        //}
    }
}

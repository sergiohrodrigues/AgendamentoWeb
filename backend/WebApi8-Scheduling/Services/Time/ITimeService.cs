using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Time
{
    public interface ITimeService
    {
        List<DayWithTimesModel> GenerateSchedulesOfTheYear();
        void RemoveDay(ref List<DayWithTimesModel> days, DateTime dayToRemove);
        //void RemoveTimeFromDay(ref List<DayWithTimesModel> days, DateTime day, TimeSpan timeToRemove);
    }
}

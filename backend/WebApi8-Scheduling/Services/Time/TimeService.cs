using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Time
{
    public class TimeService : ITimeService
    {
        private readonly AppDbContext _context;

        public TimeService(AppDbContext context)
        {
            _context = context;
        }
        
        public List<DiaEHorariosModel> GenerateSchedulesOfTheYear(int pProfissionalId)
        {
            var daysWithTimes = new List<DiaEHorariosModel>();
            var startDate = DateTime.Today;
            var endDate = new DateTime(startDate.Year, 12, 31);
            var now = DateTime.Now;
            
            var datasIndisponiveis = _context.AgendaIndisponivel
                .Where(a => a.Data != null)
                .Where(p => p.ProfissionalId == pProfissionalId)
                .Select(a => a.Data.Date)
                .ToHashSet();

            for (var data = startDate; data <= endDate; data = data.AddDays(1))
            {
                if (data.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                if (data == DateTime.Today && now.Hour >= 19)
                    continue;

                if (datasIndisponiveis.Contains(data.Date))
                    continue;

                var day = new DiaEHorariosModel(data);
                day.Horarios = new List<string>();

                for (int hourUtc = 11; hourUtc <= 23; hourUtc++)
                {
                    if (hourUtc == 15 || hourUtc == 16)
                        continue;

                    var utcTime = new DateTime(data.Year, data.Month, data.Day, hourUtc, 0, 0, DateTimeKind.Utc);
                    day.Horarios.Add(utcTime.ToString("HH:mm"));
                }

                daysWithTimes.Add(day);
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

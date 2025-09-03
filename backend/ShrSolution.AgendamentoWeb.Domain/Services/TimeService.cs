// using ShrSolution.AgendamentoWeb.Domain.Models;
// using WebApi8_Scheduling.Domain.Services.Interfaces;
// using WebApi8_Scheduling.Infra.Data;
//
// namespace WebApi8_Scheduling.Domain.Services
// {
//     public class TimeService : ITimeService
//     {
//         private readonly AppDbContext _context;
//
//         public TimeService(AppDbContext context)
//         {
//             _context = context;
//         }
//         
//         public List<DiaEHorarios> GenerateSchedulesOfTheYear(int pProfissionalId)
//         {
//             var daysWithTimes = new List<DiaEHorarios>();
//             var startDate = DateTime.Today;
//             var endDate = new DateTime(startDate.Year, 12, 31);
//             var now = DateTime.Now;
//             
//             var datasIndisponiveis = _context.AgendaIndisponivel
//                 .Where(a => a.Data != null)
//                 .Where(p => p.ProfissionalId == pProfissionalId)
//                 .Select(a => a.Data.Date)
//                 .ToHashSet();
//
//             for (var data = startDate; data <= endDate; data = data.AddDays(1))
//             {
//                 if (data.DayOfWeek == DayOfWeek.Sunday)
//                     continue;
//
//                 if (data == DateTime.Today && now.Hour >= 19)
//                     continue;
//
//                 if (datasIndisponiveis.Contains(data.Date))
//                     continue;
//
//                 var day = new DiaEHorarios(data);
//                 day.Horarios = new List<string>();
//
//                 for (int hourUtc = 8; hourUtc <= 20; hourUtc++)
//                 {
//                     if (hourUtc == 11 || hourUtc == 14)
//                         continue;
//
//                     var utcTime = new DateTime(data.Year, data.Month, data.Day, hourUtc, 0, 0, DateTimeKind.Utc);
//                     day.Horarios.Add(utcTime.ToString("HH:mm"));
//                 }
//
//                 daysWithTimes.Add(day);
//             }
//
//             return daysWithTimes;
//         }
//
//
//
//
//
//
//         // public void RemoveDay(ref List<DayWithTimesModel> days, DateTime dayToRemove)
//         // {
//         //     days.RemoveAll(d => d.Day.Date == dayToRemove.Date);
//         // }
//
//         //public void RemoveTimeFromDay(ref List<DayWithTimesModel> days, DateTime day, TimeSpan timeToRemove)
//         //{
//         //    var dayEntry = days.FirstOrDefault(d => d.Day.Date == day.Date);
//
//         //    if (dayEntry != null)
//         //    {
//         //        dayEntry.Times.RemoveAll(h => h.TimeOfDay == timeToRemove);
//         //    }
//         //}
//     }
// }

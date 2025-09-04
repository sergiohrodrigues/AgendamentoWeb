using ShrSolution.AgendamentoWeb.Domain.Models;

namespace WebApi8_Scheduling.Domain.Services.Interfaces
{
    public interface ITimeService
    {
        List<DiaEHorarios> GenerateSchedulesOfTheYear(int pProfissionalId);
        // void RemoveDay(ref List<DayWithTimesModel> days, DateTime dayToRemove);
        //void RemoveTimeFromDay(ref List<DayWithTimesModel> days, DateTime day, TimeSpan timeToRemove);
    }
}

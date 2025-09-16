using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Services.Interfaces
{
    public interface IAgendamentoInterface
    {
        void AdicionarAgendamento(Agendamento pAgendamento);
        // Task<ResponseModel<Agendamento>> CreateSheduling(SchedulingCreateDto scheduling);
        // IQueryable<Agendamento> DeleteScheduling(int idScheduling);
    }
}

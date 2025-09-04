using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Services.Interfaces
{
    public interface IAgendamentoInterface
    {
        Task<ResponseModel<List<Agendamento>>> GetAllSchedulings(int EnterpriseId);
        // Task<ResponseModel<Agendamento>> CreateSheduling(SchedulingCreateDto scheduling);
        Task<ResponseModel<Agendamento>> DeleteScheduling(int idScheduling);
    }
}

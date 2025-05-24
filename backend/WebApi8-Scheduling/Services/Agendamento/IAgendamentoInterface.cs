using WebApi8_Scheduling.Dto.Scheduling;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Scheduling
{
    public interface IAgendamentoInterface
    {
        Task<ResponseModel<List<AgendamentoModel>>> GetAllSchedulings(int EnterpriseId);
        Task<ResponseModel<AgendamentoModel>> CreateSheduling(SchedulingCreateDto scheduling);
        Task<ResponseModel<AgendamentoModel>> DeleteScheduling(int idScheduling);
    }
}

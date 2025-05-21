using WebApi8_Scheduling.Dto.AgendaBase;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.AgendaBase
{
    public interface IAgendaDisponivelService
    {
        Task<ResponseModel<AgendaDisponivel>> CreateAgendaBase(AgendaBaseCreateDto pAgendaBaseDto);
        Task<ResponseModel<List<AgendaDisponivel>>> AddDefaultSchedules(int pProfessionalId);
        Task<ResponseModel<AgendaDisponivel>> EditAgendaBase(int pProfessionalId, AgendaBaseEditDto pAgendaBaseEditDto);
    }
}

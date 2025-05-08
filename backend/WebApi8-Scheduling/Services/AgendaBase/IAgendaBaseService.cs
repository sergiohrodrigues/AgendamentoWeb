using WebApi8_Scheduling.Dto.AgendaBase;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.AgendaBase
{
    public interface IAgendaBaseService
    {
        Task<ResponseModel<AgendaBaseModel>> CreateAgendaBase(AgendaBaseCreateDto pAgendaBaseDto);
        Task<ResponseModel<List<AgendaBaseModel>>> AddDefaultSchedules(int pProfessionalId);
        Task<ResponseModel<AgendaBaseModel>> EditAgendaBase(int pProfessionalId, AgendaBaseEditDto pAgendaBaseEditDto);
    }
}

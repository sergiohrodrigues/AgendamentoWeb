using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Professional
{
    public interface IProfessionalService
    {
        Task<ResponseModel<ProfessionalModel>> CreateProfessional(ProfessionalCreateDto pProfessional);
        Task<ResponseModel<List<ProfessionalModel>>> GetAllProfessional(int enterpriseId);
        Task<ResponseModel<List<string>>> GetSchedulesProfessional(int pDayWeek, int pProfessionalId);
        Task<ResponseModel<List<DateTime>>> BuscarHorariosDisponiveis(int profissionalId, DateTime dataInicial, DateTime dataFinal);
    }
}

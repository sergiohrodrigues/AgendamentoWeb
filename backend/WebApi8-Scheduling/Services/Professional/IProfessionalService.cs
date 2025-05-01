using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Professional
{
    public interface IProfessionalService
    {
        Task<ResponseModel<ProfessionalModel>> CreateProfessional(ProfessionalCreateDto pProfessional);
    }
}

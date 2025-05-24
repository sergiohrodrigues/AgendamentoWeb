using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Dto.Service;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Professional
{
    public interface IProfessionalService
    {
        Task<ResponseModel<ProfissionalModel>> CreateProfessional(ProfessionalCreateDto pProfessional);
        Task<ResponseModel<List<ProfissionalModel>>> GetAllProfessional(int enterpriseId);
        Task<ResponseModel<List<ProfissionalServico>>> BuscarServicosProfissional(int profissionalId);
    }
}

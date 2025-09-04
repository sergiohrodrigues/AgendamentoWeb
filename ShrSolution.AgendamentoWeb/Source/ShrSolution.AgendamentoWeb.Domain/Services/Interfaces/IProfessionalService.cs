using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Services.Interfaces
{
    public interface IProfessionalService
    {
        public Task<Profissional?> ObterPorId(int pProfessionalId);
        // Task<ResponseModel<Profissional>> CreateProfessional(ProfessionalCreateDto pProfessional);
        // Task<ResponseModel<List<Profissional>>> GetAllProfessional(int enterpriseId);
        // Task<ResponseModel<List<ProfissionalServico>>> BuscarServicosProfissional(int profissionalId);
        // Task<ResponseModel<string>> RemoverDiaDaAgendaDoProfissional(int profissionalId, RemoverDiaProfissionalDto pRemoverDiaProfissional);
    }
}

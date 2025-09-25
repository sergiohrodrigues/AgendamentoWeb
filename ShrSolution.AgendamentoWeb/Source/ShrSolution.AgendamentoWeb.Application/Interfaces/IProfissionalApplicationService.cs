using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IProfissionalApplicationService
{
    Task<ProfissionalViewModel?> ObterProfissionalPorId(int pEmpresaId);
    Task<AdicionarProfissionalViewModel?> Adicionar(AdicionarProfissionalViewModel pAdicionarProfissionalViewModel);
}
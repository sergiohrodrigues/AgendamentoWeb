using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IProfissionalApplicationService
{
    Task<AdicionarProfissionalViewModel?> Adicionar(AdicionarProfissionalViewModel pAdicionarProfissionalViewModel);
}
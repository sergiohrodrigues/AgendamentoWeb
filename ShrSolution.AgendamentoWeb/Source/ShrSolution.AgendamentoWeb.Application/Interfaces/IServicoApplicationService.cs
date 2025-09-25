using ShrSolution.AgendamentoWeb.Application.ViewModels.Servico;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IServicoApplicationService
{
    Task<ServicoViewModel?> ObterServicoPorId(int pServicoId);
    Task<AdicionarServicoViewModel?> Adicionar(AdicionarServicoViewModel pAdicionarServicoViewModel);
}
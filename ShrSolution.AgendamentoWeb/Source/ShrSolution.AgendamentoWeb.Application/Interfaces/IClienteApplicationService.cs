using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IClienteApplicationService
{
    Task<ClienteViewModel?> ObterClientePorId(int pClienteId);
    Task<AdicionarClienteViewModel> Adicionar(AdicionarClienteViewModel pClienteViewModel);
}
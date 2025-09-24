using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IClienteApplicationService
{ 
   public Task<ClienteViewModel?> ObterClientePorId(int pClienteId);
   public List<ClienteViewModel> ObterTodosClientes();
   public Task<AdicionarClienteViewModel> AdicionarCliente(AdicionarClienteViewModel pClienteViewModel);
   public Task<EditarClienteViewModel> EditarCliente(int pClienteId, EditarClienteViewModel pEditarClienteViewModel);
   public Task<bool> RemoverCliente(int pClienteId);
}
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IClienteApplicationService
{ 
   public Task<ClienteViewModel?> ObterClientePorId(int pClienteId);
   //public List<ClienteViewModel> ObterTodosClientes();
   public Task<AdicionarClienteViewModel> Adicionar(AdicionarClienteViewModel pClienteViewModel);
}
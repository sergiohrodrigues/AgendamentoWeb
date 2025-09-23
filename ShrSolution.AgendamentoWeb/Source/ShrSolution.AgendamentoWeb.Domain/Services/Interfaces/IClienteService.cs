using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Repositories;

namespace ShrSolution.AgendamentoWeb.Domain.Services.Interfaces
{
    public interface IClienteService
    {
        //Task<ResponseModel<List<ClientModel>>> GetAllClients(int idUser);
        public Task<Cliente?> ObterPorId(int pClienteId);
        void Adicionar(Cliente pCliente);
        // Task<ResponseModel<Cliente>> UpdateClient(int clientId, ClientUpdateDto pClient);
        // Task<ResponseModel<Cliente>> DeleteClient(int pClientId);
    }
}

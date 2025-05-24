using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Cliente
{
    public interface IClienteInterface
    {
        //Task<ResponseModel<List<ClientModel>>> GetAllClients(int idUser);
        Task<ResponseModel<ClienteModel>> CriarCliente(CriarClienteDto pCliente);
        Task<ResponseModel<ClienteModel>> UpdateClient(int clientId, ClientUpdateDto pClient);
        Task<ResponseModel<ClienteModel>> DeleteClient(int pClientId);
    }
}

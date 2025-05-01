using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Client
{
    public interface IClientInterface
    {
        //Task<ResponseModel<List<ClientModel>>> GetAllClients(int idUser);
        Task<ResponseModel<ClientModel>> CreateClient(ClientCreateDto pClient);
        Task<ResponseModel<ClientModel>> UpdateClient(int clientId, ClientUpdateDto pClient);
        Task<ResponseModel<ClientModel>> DeleteClient(int pClientId);
    }
}

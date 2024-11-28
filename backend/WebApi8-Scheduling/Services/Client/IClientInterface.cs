using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Client
{
    public interface IClientInterface
    {
        Task<ResponseModel<List<ClientModel>>> GetAllClients(int idUser);
        Task<ResponseModel<ClientModel>> CreateClient(ClientCreateDto client);
        Task<ResponseModel<ClientModel>> UpdateClient(ClientUpdateDto client);
        Task<ResponseModel<ClientModel>> DeleteClient(int idClient);
    }
}

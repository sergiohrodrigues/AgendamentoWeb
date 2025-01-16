using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Client
{
    public class ClientService : IClientInterface
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ClientModel>>> GetAllClients(int idUser)
        {
            ResponseModel<List<ClientModel>> respost = new ResponseModel<List<ClientModel>>();

            try
            {
                var clients = await _context.Clients
                    .Include(a => a.Enterprise)
                    .Where(c => c.EnterpriseId == idUser)
                    .ToListAsync();

                if (!clients.Any()){
                    respost.Mensagem = "User not found!";
                    return respost;
                }

                respost.Mensagem = "Get all clients successfully!";
                respost.Dados = clients;
                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<ClientModel>> CreateClient(ClientCreateDto client)
        {

           ResponseModel<ClientModel> respost = new ResponseModel<ClientModel>();

            try
            {
                var EnterpriseId = await _context.Enterprise.FirstOrDefaultAsync(a => a.Id == client.EnterpriseId);

                if(EnterpriseId == null)
                {
                    respost.Mensagem = "User not found!";
                    return respost;
                }

                var newClient = new ClientModel()
                {
                    Name = client.Name,
                    LastName = client.LastName,
                    Email = client.Email,
                    Tel = client.Tel,
                    EnterpriseId = client.EnterpriseId
                };

                _context.Clients.Add(newClient);
                _context.SaveChanges();

                respost.Dados = newClient;
                respost.Mensagem = "Customer created successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<ClientModel>> UpdateClient(ClientUpdateDto clientUpdateDto)
        {
            ResponseModel<ClientModel> respost = new ResponseModel<ClientModel>();

            try
            {
                var user = await _context.Clients.FirstOrDefaultAsync(a => a.Id == clientUpdateDto.Id);

                if (user == null)
                {
                    respost.Mensagem = "User not found!";
                    return respost;
                }

                user.Name = clientUpdateDto.Name;
                user.LastName = clientUpdateDto.LastName;
                user.Email = clientUpdateDto.Email;
                user.Tel = clientUpdateDto.Tel;

                _context.Clients.Update(user);
                _context.SaveChanges();

                respost.Dados = user;
                respost.Mensagem = "User Updated successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<ClientModel>> DeleteClient(int idClient)
        {
            ResponseModel<ClientModel> respost = new ResponseModel<ClientModel>();

            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(clientBanco => clientBanco.Id == idClient);

                if(client == null)
                {
                    respost.Mensagem = "Client not found!";
                    return respost;
                }

                _context.Clients.Remove(client);
                _context.SaveChanges();

                respost.Dados = client;
                respost.Mensagem = "User Deleted successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }
    }
}
